namespace DINET.Prueba.Utilitarios
{
    public static class LogHelper
    {
        public static void RegistrarLog(string mensaje)
        {
            var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            var archivo = Path.Combine(ruta, $"Log_{DateTime.Now:yyyyMMdd}.txt");

            using (var writer = new StreamWriter(archivo, true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {mensaje}");
            }
        }
    }
}