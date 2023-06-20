using DataGridStyle.Models;
using GL.Common.Controls.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataGridStyle.ViewModels
{
    internal class TestViewModel : BindableBase
    {
        public DelegateCommand<DeviceInfo> CheaterCommand { get; set; }


        private ObservableCollection<DeviceInfo> _students;

        public ObservableCollection<DeviceInfo> students
        {
            get { return _students; }
            set { _students = value; RaisePropertyChanged(); }
        }
        public TestViewModel()
        {
            students = new ObservableCollection<DeviceInfo>();
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 1,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.在线,
                ExamInfo = new ExamInfo()
                {
                    Name = "张三",
                    IdCard = "3302119******5324"
                },
                Code = "K21",
                CodeName = "10kv高压柜（送）电操作"
            });
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 2,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.在线,
                ExamInfo = new ExamInfo()
                {
                    Name = "李四",
                    IdCard = "3302119******5324"
                },
                Code = "K22",
                CodeName = "10kv高压柜（送）电操作"
            }); students.Add(new DeviceInfo()
            {
                DeviceNumber = 3,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.考试中,
                ExamInfo = new ExamInfo()
                {
                    Name = "王五",
                    IdCard = "3302119******5324"
                },
                Code = "K23",
                CodeName = "10kv高压柜（送）电操作"
            });
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 4,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.离线,
                ExamInfo = new ExamInfo()
                {
                    Name = "周傲笑",
                    IdCard = "3302119******5324"
                },
                Code = "K24",
                CodeName = "10kv高压柜（送）电操作"

            }); students.Add(new DeviceInfo()
            {
                DeviceNumber = 5,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.离线,
                ExamInfo = new ExamInfo()
                {
                    Name = "周傲笑",
                    IdCard = "3302119******5324"
                },
                Code = "K24",
                CodeName = "10kv高压柜（送）电操作"
            });
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 6,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.离线,
                ExamInfo = new ExamInfo()
                {
                    Name = "周傲笑",
                    IdCard = "3302119******5324"
                },
                Code = "K24",
                CodeName = "10kv高压柜（送）电操作"
            });
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 7,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.离线,
                ExamInfo = new ExamInfo()
                {
                    Name = "周傲笑",
                    IdCard = "3302119******5324"
                },
                Code = "K24",
                CodeName = "10kv高压柜（送）电操作"
            });
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 7,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.在线,
                ExamInfo = new ExamInfo()
                {
                    Name = "周傲笑",
                    IdCard = "3302119******5324"
                },
                Code = "K24",
                CodeName = "10kv高压柜（送）电操作"
            });
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 7,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.考试中,
                ExamInfo = new ExamInfo()
                {
                    Name = "周傲笑",
                    IdCard = "3302119******5324"
                },
                Code = "K24",
                CodeName = "10kv高压柜（送）电操作"
            });
            students.Add(new DeviceInfo()
            {
                DeviceNumber = 7,
                DeviceName = "高压（高压柜、变压器）",
                Type = DeviceType.考试中,
                ExamInfo = new ExamInfo()
                {
                    Name = "周傲笑",
                    IdCard = "3302119******5324"
                },
                Code = "K24",
                CodeName = "10kv高压柜（送）电操作"
            });
            // 根据状态进行排序  考试中>在线>离线
            students = new ObservableCollection<DeviceInfo>(students.OrderBy(e =>
            {
                switch (e.Type)
                {
                    case DeviceType.考试中:
                        return 0;
                    case DeviceType.在线:
                        return 1;
                    case DeviceType.离线:
                        return 2;
                    default:
                        return 2;
                }
            }));
            CheaterCommand = new DelegateCommand<DeviceInfo>((a) =>
            {
                MessageBoxTip.ShowError(a.DeviceNumber.ToString());
            });
            Task.Run( async () =>
            {
                while (true)
                {
                 await   Application.Current.Dispatcher.Invoke(async() =>
                    {
                        students.Add(new DeviceInfo()
                        {
                            DeviceNumber = 7,
                            DeviceName = "高压（高压柜1、变压器）",
                            Type = DeviceType.考试中,
                            ExamInfo = new ExamInfo()
                            {
                                Name = "周傲笑",
                                IdCard = "3302119******5324"
                            },
                            Code = "K24",
                            CodeName = "10kv高压柜（送）电操作"
                        });
                        students = new ObservableCollection<DeviceInfo>(students.OrderBy(e =>
                        {
                            switch (e.Type)
                            {
                                case DeviceType.考试中:
                                    return 0;
                                case DeviceType.在线:
                                    return 1;
                                case DeviceType.离线:
                                    return 2;
                                default:
                                    return 2;
                            }
                        }));
                    });
                  await  Task.Delay(5000);   
                  
                }

            });

        }

    }
    class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
    }
}
