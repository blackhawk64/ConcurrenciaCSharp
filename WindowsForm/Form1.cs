using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        private string apiUrl;
        private HttpClient httpClient;
        private CancellationTokenSource cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
            apiUrl = "https://localhost:7168";
            httpClient = new HttpClient();
        }

        private void loadingGif_Click(object sender, EventArgs e)
        {

        }

        private async void botonIniciar_Click(object sender, EventArgs e)
        {
            #region Anotaciones_1
            //cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(3));
            #endregion
            
            loadingGif.Visible = true;

            #region Anotaciones_2
            //pgProcesamiento.Visible = true;
            //var reportarProgreso = new Progress<int>(ReportarProgesoTarjetas);
            ////await Esperar();
            ////var nombre = nombreInput.Text;
            //var tarjetas = await ObtenerTarjetasCredito(1000);
            //var stopWatch = new Stopwatch();
            //stopWatch.Start();

            //try
            //{
            //    await ProcesarTarjetas(tarjetas, reportarProgreso, cancellationTokenSource.Token);
            //    //var saludo = await ObtenerSaludo(nombre);
            //    //MessageBox.Show(saludo);
            //}
            //catch (HttpRequestException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}catch(TaskCanceledException ex)
            //{
            //    MessageBox.Show("Operación cancelada");
            //}

            //MessageBox.Show($"Operacion finalizada en {stopWatch.ElapsedMilliseconds/1000.0} segundos");

            //// Patron de reintento
            //try
            //{
            //    var GetSaludo = await PatronReintento(ObtenerSaludo);
            //    Console.WriteLine($"Operacion realizada con exito: {GetSaludo}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error al intentar enlazar al servidor");
            //}

            //// Patron Solo una tarea
            //string[] personas = new string[] { "Angel", "Laura", "Andrea", "Jose", "Raul", "David" };
            // Ejemplo 1 - Patron una sola tarea
            //var tareasHttp = personas.Select(p => ObtenerSaludoConDelay(p, cancellationTokenSource.Token));
            //var tareaFinalizada = await Task.WhenAny(tareasHttp);
            //var contenido = await tareaFinalizada;
            //Console.WriteLine(contenido.ToUpper());
            //cancellationTokenSource.Cancel();
            // Ejemplo 2 - Patron una sola tarea
            //var tareasHttp = personas.Select(x =>
            //{
            //    Func<CancellationToken, Task<string>> funcion = (ct) => ObtenerSaludoConDelay(x, ct);
            //    return funcion;
            //});

            //var contenido = await PatronSoloUnaTarea(tareasHttp);
            //Console.WriteLine(contenido.ToUpper());
            #endregion

            #region Paralelismo
            //var directorioActual = AppDomain.CurrentDomain.BaseDirectory;
            //var destinoBaseSecuencial = Path.Combine(directorioActual, @"Imagenes\resultado-secuencial");
            //var destinoBaseParalelo = Path.Combine(directorioActual, @"Imagenes\resultado-paralelo");
            //PrepararEjecucion(destinoBaseParalelo, destinoBaseSecuencial);

            //var imagenes = ObtenerImagenes();
            //// Ejemplo secuencial
            //var stopwatch = new Stopwatch();
            //stopwatch.Start();

            //foreach (var imagen in imagenes)
            //{
            //    await ProcesarImagen(destinoBaseSecuencial, imagen);
            //}

            //double tiempoSecuencial = stopwatch.ElapsedMilliseconds / 1000.0;

            //Console.WriteLine("Procesamiento secuencial: {0} segundos", tiempoSecuencial);

            //stopwatch.Restart();
            //// Ejemplo paralelo
            //var imagenesTareas = imagenes.Select(async imagen => await ProcesarImagen(destinoBaseParalelo, imagen));
            //await Task.WhenAll(imagenesTareas);

            //double tiempoParalelo = stopwatch.ElapsedMilliseconds / 1000.0;

            //Console.WriteLine("Procesamiento parelelo: {0} segundos", tiempoParalelo);

            //EscribirComparacion(tiempoSecuencial, tiempoParalelo);

            #endregion

            #region Ejemplo_ParallelFor
            var columnasMatA = 1100;
            var filas = 1000;
            var columnasMatB = 1750;

            var matrizA = OperacionesMatrices.InicializarMatriz(filas, columnasMatA);
            var matrizB = OperacionesMatrices.InicializarMatriz(columnasMatA, columnasMatB);
            var resultado = new double[filas, columnasMatB];

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await Task.Run(() => OperacionesMatrices.MultiplicarMatricesSecuencial(matrizA, matrizB, resultado));

            var tiempoSecuencial = stopWatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Duración de operación secuencual: {0} segundos",tiempoSecuencial);

            resultado = new double[filas, columnasMatB];
            stopWatch.Restart();

            await Task.Run(() => OperacionesMatrices.MultiplicarMatricesParalelo(matrizA, matrizB, resultado));

            var tiempoParalelo = stopWatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Duración de operación paralela: {0} segundos", tiempoParalelo);

            EscribirComparacion(tiempoSecuencial, tiempoParalelo);

            #endregion

            loadingGif.Visible = false;

            #region Anotaciones_3
            //pgProcesamiento.Visible= false;
            //pgProcesamiento.Value = 0;
            #endregion
        }

        private async Task<T> PatronSoloUnaTarea<T>(IEnumerable<Func<CancellationToken, Task<T>>> funciones)
        {
            var cts = new CancellationTokenSource();
            var tareas = funciones.Select(funcion => funcion(cts.Token));
            var tareaFinalizada = await Task.WhenAny(tareas);

            cts.Cancel();
            return await tareaFinalizada;
        }

        private async Task<T> PatronReintento<T>(Func<string, Task<T>> funcion, int reintentos = 3, int tiempoEspera = 500)
        {
            for (int i = 0; i < reintentos-1; i++)
            {
                try
                {
                    return await funcion("Alexis");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.Delay(tiempoEspera);
                }
            }

            return await funcion("Alexis");
        }

        private async Task ProcesarTarjetas(List<string> tarjetas
                ,IProgress<int> progress = null
                ,CancellationToken cancellationToken = default)
        {
            using var semaforo = new SemaphoreSlim(200);

            var tareas = new List<Task<HttpResponseMessage>>();
            int indice = 0;

            tareas = tarjetas.Select(async tarjeta =>
            {
                var json = JsonConvert.SerializeObject(tarjeta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await semaforo.WaitAsync();
                try
                {
                    var tareaInterna = await httpClient.PostAsync($"{apiUrl}/tarjetas", content, cancellationToken);

                    //if (progress != null)
                    //{
                    //    indice++;
                    //    var porcentaje = (double)indice / tarjetas.Count;
                    //    porcentaje = porcentaje * 100;
                    //    int porcentajeInt = (int)Math.Round(porcentaje, 0);
                    //    progress.Report( porcentajeInt );
                    //}

                    return tareaInterna;
                }
                finally
                {

                    semaforo.Release();
                }
            }).ToList();

            var respuestasTareas = Task.WhenAll(tareas);

            if (progress != null)
            {
                while (await Task.WhenAny(respuestasTareas, Task.Delay(900)) != respuestasTareas)
                {
                    var tareasCompletadas = tareas.Where(x => x.IsCompleted).Count();

                    var porcentaje = ((double)tareasCompletadas / tarjetas.Count) * 100;
                    progress.Report((int)Math.Round(porcentaje, 0));
                }
            }

            var respuestas = await respuestasTareas;

            List<string> tarjetasRechazadas = new List<string>();

            respuestas.ToList().ForEach(async (respuesta) =>
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                var respuestaTarjeta = JsonConvert.DeserializeObject<RespuestaTarjeta>(contenido);

                if (!respuestaTarjeta.Aprobada)
                    tarjetasRechazadas.Add(respuestaTarjeta.Tarjeta);
            });

            tarjetasRechazadas.ForEach((tarjeta) =>
            {
                Console.WriteLine(tarjeta);
            });
        }

        private void ReportarProgesoTarjetas(int porcentaje)
        {
            pgProcesamiento.Value = porcentaje;
        }

        private async Task<List<string>> ObtenerTarjetasCredito(int cantidad)
        {
            return await Task.Run(() => {
                var tarjetas = new List<string>();

                for (int i = 0; i < cantidad; i++)
                {
                    tarjetas.Add(i.ToString().PadLeft(16, '0'));
                }

                return tarjetas;
            });
        }

        private async Task Esperar()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
        }

        private async Task<string> ObtenerSaludo(string nombre)
        {
            using (var respuesta = await httpClient.GetAsync($"{apiUrl}/saludosaa/{nombre}"))
            {
                respuesta.EnsureSuccessStatusCode();
                var saludo = await respuesta.Content.ReadAsStringAsync();
                return saludo;
            }
        }

        private async Task<string> ObtenerSaludoConDelay(string nombre, CancellationToken cancellationToken)
        {
            using (var respuesta = await httpClient.GetAsync($"{apiUrl}/saludos/delay/{nombre}", cancellationToken))
            {
                respuesta.EnsureSuccessStatusCode();
                var saludo = await respuesta.Content.ReadAsStringAsync();
                Console.WriteLine(saludo);
                return saludo;
            }
        }

        private void PrepararEjecucion(string destinoBaseParalelo, string destinoBaseSecuencial)
        {
            if (!Directory.Exists(destinoBaseParalelo))
            {
                Directory.CreateDirectory(destinoBaseParalelo);
            }

            if (!Directory.Exists(destinoBaseSecuencial))
            {
                Directory.CreateDirectory(destinoBaseSecuencial);
            }

            BorrarArchivos(destinoBaseParalelo);
            BorrarArchivos(destinoBaseSecuencial);
        }

        private void BorrarArchivos(string directorio)
        {
            var archivos = Directory.EnumerateFiles(directorio);
            foreach (var archivo in archivos)
            {
                File.Delete(archivo);
            }
        }

        private static List<Imagen> ObtenerImagenes()
        {
            var imagenes = new List<Imagen>();

            for (int i = 0; i < 5; i++)
            {
                imagenes.Add(new Imagen
                {
                    Nombre = $"Una-{i}.jpg",
                    URL = "https://images.unsplash.com/photo-1676142959192-5870a84e7b03?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"
                });

                imagenes.Add(new Imagen
                {
                    Nombre = $"Dos-{i}.jpg",
                    URL = "https://images.unsplash.com/photo-1673785677551-1786b84abad4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"
                });

                imagenes.Add(new Imagen
                {
                    Nombre = $"Tres-{i}.jpg",
                    URL = "https://images.unsplash.com/photo-1675087042892-5989eabf5261?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"
                });

                imagenes.Add(new Imagen
                {
                    Nombre = $"Cuatro-{i}.jpg",
                    URL = "https://images.unsplash.com/photo-1674720694029-f7e028dfc96e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1471&q=80"
                });

                imagenes.Add(new Imagen
                {
                    Nombre = $"Cinco-{i}.jpg",
                    URL = "https://images.unsplash.com/photo-1674078119887-8ef697419aa7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"
                });
            }

            return imagenes;
        }

        private async Task ProcesarImagen(string directorio, Imagen imagen)
        {
            try
            {
                var response = await httpClient.GetAsync(imagen.URL);
                var content = await response.Content.ReadAsByteArrayAsync();

                Bitmap bitmap;
                using (var ms = new MemoryStream(content))
                {
                    bitmap = new Bitmap(ms);
                }

                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                var destino = Path.Combine(directorio, imagen.Nombre);
                bitmap.Save(destino);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un error al recuperar la imagen de la url {imagen.URL}");
            }
        }

        private void EscribirComparacion(double tiempo1, double tiempo2)
        {
            var diferencia = tiempo2 - tiempo1;
            diferencia = Math.Round(diferencia, 2);

            var incrementoPorcentual = ((tiempo2 - tiempo1) / tiempo1) * 100;
            incrementoPorcentual = Math.Round(incrementoPorcentual,2);
            Console.WriteLine($"Diferencia de {diferencia} segundos ({incrementoPorcentual}%)");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
