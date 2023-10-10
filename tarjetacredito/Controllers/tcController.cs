using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using tarjetacredito.Models;

namespace tarjetacredito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tcController : ControllerBase
    {
        private readonly TcreditosContext _DbContext;

        public tcController(TcreditosContext dbContext)
        {
            _DbContext = dbContext;
        }

        [HttpGet]
        [Route("Cliente/{id}")]
        public async Task<IActionResult> Cliente(int id)
        {
            var responseApi = new ResponseAPI<ClienteDTO>();
            var clienteDTO = new ClienteDTO();

            try
            {
                var dbCliente = _DbContext.Clientes.FromSqlInterpolated($"EXEC sp_cliente @id={id}").AsAsyncEnumerable();

                await foreach (var cliente in dbCliente)
                {
                    clienteDTO.Id = cliente.Id;
                    clienteDTO.Nombres = cliente.Nombres;
                    clienteDTO.Apellidos = cliente.Apellidos;
                }
                if (clienteDTO.Id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = clienteDTO;
                    responseApi.Mensaje = "Exitoso";
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.Mensaje = ex.Message;
                responseApi.EsCorrecto = false;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Tarjetas/{id}")]
        public async Task<IActionResult> Tarjetas(int id)
        {
            var responseApi = new ResponseAPI<List<TarjetaDTO>>();
            var listatarjetasDTO = new List<TarjetaDTO>();

            try
            {
                var tarje = _DbContext.Tarjetas.FromSqlInterpolated($"EXEC sp_tarjetas @id={id}").AsAsyncEnumerable();
                await foreach (var item in tarje)
                {
                    listatarjetasDTO.Add(new TarjetaDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Limite = item.Limite,
                        Disponible = item.Disponible,
                        PContado = item.PContado,
                        PMinimo = item.PMinimo,
                        NTarjeta = Decrypt(item.NTarjeta, secretKey),
                    });

                }
                if (listatarjetasDTO.Count != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = listatarjetasDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }

            }
            catch (Exception ex)
            {
                responseApi.Mensaje = ex.Message;
                responseApi.EsCorrecto = false;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Movimientos/{id}")]
        public async Task<IActionResult> Movimientos(int id)
        {
            var responseApi = new ResponseAPI<List<MovimientosDTO>>();
            var movimientosDTO = new List<MovimientosDTO>();
            try
            {
                var movi = _DbContext.Movimientos.FromSqlInterpolated($"EXEC sp_movimientos @id={id}").AsAsyncEnumerable();
                await foreach (var item in movi)
                {
                    movimientosDTO.Add(new MovimientosDTO
                    {
                        Id = item.Id,
                        FTransaccion = item.FTransaccion,
                        Descripcion = item.Descripcion,
                        Monto = item.Monto,
                    });
                }
                if (movimientosDTO.Count != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = movimientosDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }

            }
            catch (Exception ex)
            {
                responseApi.Mensaje = ex.Message;
                responseApi.EsCorrecto = false;
            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Pago")]
        public async Task<IActionResult> Pago(MovimientosDTO movimiento)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                movimiento.Monto = Math.Abs(movimiento.Monto);

                var parametroId = new SqlParameter("@id", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                await _DbContext.Database.ExecuteSqlInterpolatedAsync($"EXEC sp_pago @IdTarjeta={movimiento.IdTarjeta}, @Descripcion={movimiento.Descripcion}, @FTransaccion={movimiento.FTransaccion}, @Monto={movimiento.Monto}, @id={parametroId} OUTPUT");

                var id = (int)parametroId.Value;

                if (id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = id;
                    responseApi.Mensaje = "Guardado";
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }

            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Compra")]
        public async Task<IActionResult> Compra(MovimientosDTO movimiento)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                movimiento.Monto = Math.Abs(movimiento.Monto);

                var parametroId = new SqlParameter("@id", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                await _DbContext.Database.ExecuteSqlInterpolatedAsync($"EXEC sp_compra @IdTarjeta={movimiento.IdTarjeta}, @Descripcion={movimiento.Descripcion}, @FTransaccion={movimiento.FTransaccion}, @Monto={movimiento.Monto}, @id={parametroId} OUTPUT");

                var id = (int)parametroId.Value;

                if (id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = id;
                    responseApi.Mensaje = "Guardado";
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }

            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        #region Encrypt
        private string secretKey = "6?4=#R4;7eALpwb-";
        private static string Encrypt(string texto, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.Mode = CipherMode.CFB;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(texto);
                        }
                    }
                    return Convert.ToBase64String(aesAlg.IV) + Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private static string Decrypt(string texoEncrypt, string key)
        {
            string ivString = texoEncrypt.Substring(0, 24);
            string cipherTextWithoutIV = texoEncrypt.Substring(24);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Convert.FromBase64String(ivString);
                aesAlg.Mode = CipherMode.CFB;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherTextWithoutIV)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
