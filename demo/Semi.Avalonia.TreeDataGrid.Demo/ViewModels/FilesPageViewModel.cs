using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.TreeDataGrid.Demo.ViewModels;

public class FilesPageViewModel: ObservableObject
{
    public IList<string> Drives { get; }
    private string _selectedDrive;

    public FilesPageViewModel()
    {
        Drives= DriveInfo.GetDrives().Select(x => x.Name).ToList();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            _selectedDrive = "C:\\";
        }
        else
        {
            _selectedDrive = Drives.FirstOrDefault() ?? "/";
        }
    }
}