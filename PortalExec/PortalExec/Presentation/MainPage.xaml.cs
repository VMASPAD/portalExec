using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace PortalExec.Presentation;

public sealed partial class MainPage : Page
{
    // Ruta del archivo que almacenará el valor del input
    private readonly string configFile = "Config.txt";

    public MainPage()
    {
        this.InitializeComponent();
        LoadFolderPath();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Obtener la ruta de la carpeta que se quiere explorar
        string folderPath = FolderTextBox.Text;

        // Guardar la ruta en el archivo de configuración
        SaveFolderPath(folderPath);

        // Verificar que la carpeta exista
        if (Directory.Exists(folderPath))
        {
            // Crear un arreglo con los archivos de la carpeta
            string[] files = Directory.GetFiles(folderPath, "*.lnk");

            // Limpiar el ListBox que muestra los archivos
            FilesListBox.Items.Clear();

            // Agregar cada archivo al ListBox
            foreach (string file in files)
            {
                // Obtener el nombre del archivo sin la ruta
                string fileName = Path.GetFileNameWithoutExtension(file);

                // Obtener la ruta completa del archivo ejecutable
                string executablePath = GetExecutablePath(file);

                FilesListBox.Items.Add(fileName);
            }
        }
        else
        {
           
        }
    }

    private void ExecuteButton_Click(object sender, RoutedEventArgs e)
    {
        // Obtener el botón que se presionó
        Button button = sender as Button;

        // Obtener el nombre del archivo asociado al botón
        string fileName = button.DataContext as string;

        // Obtener la ruta completa del archivo ejecutable
        string executablePath = GetExecutablePath(Path.Combine(FolderTextBox.Text, fileName + ".lnk"));

        // Verificar que el archivo exista
        if (File.Exists(executablePath))
        {
            // Crear un proceso para ejecutar el archivo
            Process process = new Process();
            process.StartInfo.FileName = executablePath;
            process.Start();
        }
        else
        {
        
        }
    }

    private void SaveFolderPath(string folderPath)
    {
        try
        {
            // Guardar la ruta en el archivo de configuración
            File.WriteAllText(configFile, folderPath);
        }
        catch (Exception ex)
        {
        
        }
    }

    private void LoadFolderPath()
    {
        try
        {
            // Verificar si el archivo de configuración existe
            if (File.Exists(configFile))
            {
                // Cargar la ruta desde el archivo de configuración
                string savedFolderPath = File.ReadAllText(configFile);

                // Establecer la ruta en el TextBox
                FolderTextBox.Text = savedFolderPath;
            }
        }
        catch (Exception ex)
        {
        
        }
    }

    private string GetExecutablePath(string shortcutPath)
    {
        // Crear un objeto WshShell
        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

        // Abrir el archivo de acceso directo
        IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);

        // Obtener la ruta del archivo ejecutable
        return shortcut.TargetPath;
    }
}
