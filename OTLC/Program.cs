using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OTLC
{
    static class Program
    {        
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
           //InstallUpdateSyncWithInfo();
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Inicio());
           // Application.Run(new Puntos());
        }
        
        private static void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show(String.Format(
                        @"La nueva versión de la aplicación no puede ser descargada en estos momentos.\n
      Por favor, revise la connexión de red o pruébelo un poco más tarde. Error: {0}",
                        dde.Message, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation));
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show(String.Format(
                        @"No se puede verificar la nueva versión de la aplicación. La publicación ClickOnce está corrupta.\n 
      Por favor, redistribuya de nuevo la aplicación y pruébelo un poco más tarde. Error: {0}",
                        ide.Message, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation));
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show(String.Format(
                        @"La aplicación no se puede actualizar. Parece ser que la publicación no es una aplicación ClickOnce válida. Error: {0}",
                        ioe.Message, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation));
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    //if (!info.IsUpdateRequired)
                    //{
                    //    DialogResult dr = MessageBox.Show(
                    //        string.Format(@"Se ha encontrado disponible una actualización. Desea actualitzar la aplicación a la versión '{0}'?",
                    //        info.AvailableVersion.ToString()),
                    //        Application.ProductName, MessageBoxButtons.OKCancel,
                    //        MessageBoxIcon.Information);
                    //    if (!(DialogResult.OK == dr))
                    //    {
                    //        doUpdate = false;
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show(
                    //        String.Format(@"Esta aplicación ha detectado que la versión mínima de l'aplicació es la versión '{0}', \n
                    //                        i actualmente se está utilizando la versión '{1}'. \n
                    //                        A continuación la aplicación se actualitzará y reiniciará.",
                    //        info.MinimumRequiredVersion.ToString(),
                    //        ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()),
                    //        Application.ProductName, MessageBoxButtons.OK,
                    //        MessageBoxIcon.Information);
                    //}

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            //MessageBox.Show(@"La aplicación se ha actualitzado correctamente, y a continuación se reiniciará.",
                            //    Application.ProductName, MessageBoxButtons.OK,
                            //    MessageBoxIcon.Information);
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show(String.Format(
                                @"La nueva versión de la aplicación no se puede instalar en estos momentos.nn
                                Por favor, revise la connexión de red o pruébelo un poco más tarde. Error: {0}",
                                dde.Message, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation));
                            return;
                        }
                    }
                }
                //else
                //{
                //    MessageBox.Show(@"No se han encontrado actualitzacions disponibles de la aplicación.",
                //        Application.ProductName, MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                //}
            }
        }

    }
}
