using AvaloniaPlatformApp.Common;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaPlatformApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        private string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                this.RaiseAndSetIfChanged(ref _phoneNumber, value);
            }
        }

        public ReactiveCommand<string, Unit> _DialCommand;
        public ReactiveCommand<Unit, Unit> _DeleteCommand;
        public ReactiveCommand<Unit, Unit> _CallCommand;


        public ReactiveCommand<string,Unit> DialCommand {
            get {
                return _DialCommand ??= ReactiveCommand.Create<string>(digit =>
                {
                    if (PhoneNumber.Length < 20)
                        PhoneNumber += digit;
                }); 
                 
            } 
        }
        public ReactiveCommand<Unit, Unit> DeleteCommand { get
            {
                return _DeleteCommand ?? ReactiveCommand.Create(() =>
                {
                    if (!string.IsNullOrEmpty(PhoneNumber))
                        PhoneNumber = PhoneNumber[..^1];
                });
            }
        }
        public ReactiveCommand<Unit, Unit> CallCommand { get
            {
                return _CallCommand ?? ReactiveCommand.Create(() =>
                {
                    if (!string.IsNullOrEmpty(PhoneNumber))
                    {
                        // 这里可以弹窗、日志等
                        System.Diagnostics.Debug.WriteLine($"正在拨打: {PhoneNumber}");
                        PhoneNumber = string.Empty;
                    }
                });
            }
        }

      

    }


 
}
