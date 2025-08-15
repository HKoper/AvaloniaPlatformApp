using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPlatformApp.ViewModels
{
    public class ListItemTemplate
    {
        public string Name { get; set; }
        public StreamGeometry? ListItemIcon { get; set; }
        public Type ModelType { get; set; }
        public ObservableCollection<ListItemTemplate> Children { get; set; } = new();
        public ListItemTemplate(Type modelType, string icon)
        {
            this.ModelType = modelType;
            this.Name = modelType.Name.Replace("PageViewModel", "").Replace("ViewModel", "");

            App.Current!.TryFindResource(icon, out var res);
            ListItemIcon = res as StreamGeometry;
        }
    }
}
