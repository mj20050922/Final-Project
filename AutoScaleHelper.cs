using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace 期末專題
{
    internal class AutoScaleHelper
    {
        private Form targetForm;
        private Size originalFormSize;
        private Dictionary<Control, ControlProperties> controlProperties;

        // 建構子：傳入您要自動縮放的 Form
        public AutoScaleHelper(Form form)
        {
            targetForm = form ?? throw new ArgumentNullException(nameof(form));
            // 訂閱 Form 的 Load 和 Resize 事件
            targetForm.Load += OnFormLoad;
            targetForm.Resize += OnFormResize;
        }

        // 在 Form 載入時，記錄所有現有控件的原始屬性
        private void OnFormLoad(object sender, EventArgs e)
        {
            originalFormSize = targetForm.ClientSize;
            controlProperties = new Dictionary<Control, ControlProperties>();
            SaveControlProperties(targetForm);
        }

        // 遞迴儲存區域中所有控件的原始位置、大小及字型
        private void SaveControlProperties(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                controlProperties[ctrl] = new ControlProperties
                {
                    OriginalLocation = ctrl.Location,
                    OriginalSize = ctrl.Size,
                    OriginalFontSize = ctrl.Font.Size
                };

                // 遞迴處理容器控件中的子控件
                if (ctrl.Controls.Count > 0)
                    SaveControlProperties(ctrl);
            }
        }

        // 在 Form Resize 事件中依據比例重新設定控件屬性
        private void OnFormResize(object sender, EventArgs e)
        {
            // 計算水平與垂直方向的縮放比例
            float scaleX = (float)targetForm.ClientSize.Width / originalFormSize.Width;
            float scaleY = (float)targetForm.ClientSize.Height / originalFormSize.Height;
            // 為保持比例，取較小者
            float scale = Math.Min(scaleX, scaleY);

            foreach (var kvp in controlProperties)
            {
                Control ctrl = kvp.Key;
                ControlProperties props = kvp.Value;

                // 調整位置與大小
                ctrl.Location = new Point((int)(props.OriginalLocation.X * scale), (int)(props.OriginalLocation.Y * scale));
                ctrl.Size = new Size((int)(props.OriginalSize.Width * scale), (int)(props.OriginalSize.Height * scale));
                // 調整字型大小
                ctrl.Font = new Font(ctrl.Font.FontFamily, props.OriginalFontSize * scale, ctrl.Font.Style);
            }
        }

        // 封裝控件原始屬性的類別
        private class ControlProperties
        {
            public Point OriginalLocation { get; set; }
            public Size OriginalSize { get; set; }
            public float OriginalFontSize { get; set; }
        }

    }
}