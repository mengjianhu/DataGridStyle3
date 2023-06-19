using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStyle.Models
{
    public class DeviceInfo
    {
        /// <summary>
        /// 设备序号
        /// </summary>
        public int DeviceNumber { get; set; }
        /// <summary>
        /// 设备状态
        /// </summary>
        public DeviceType Type { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 考生信息
        /// </summary>
        public ExamInfo ExamInfo { get; set; }
        /// <summary>
        /// 考生科目ID
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 考试科目名称
        /// </summary>
        public string CodeName { get; set; }
    }
    public enum DeviceType
    {
        在线,
        离线,
        考试中
    }
    public class ExamInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }
    }
}
