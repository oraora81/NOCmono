using System;
using Gtk;

namespace Nt
{
    #region Enum
    [Flags]
    public enum MessageResponse
    {
        None = 0x0001,
        Ok = 0x0002,
        Yes = 0x0008,
        No = 0x0010,
        OkCancel = 0x0020,
        YesNo = Yes | No,
    }
    #endregion
    
    public class MessageBox : Window
    {
        #region Variables
        private VBox vbox = new VBox(true, 5);
        private HBox hbox = new HBox(false, 3);
        private Alignment valign = new Alignment(0, 0.5f, 0, 0);
        private Alignment halign = new Alignment(0.5f, 0, 0, 0);
        private MessageResponse responseType;
        private string _clickedMessage = string.Empty;
        private EventHandler<CloseEventArgs> _closeHandler;
        #endregion

        #region Properties
        public MessageResponse Response
        {
            get { return responseType; }
        }
        #endregion

        public MessageBox(string text, MessageResponse responseId, EventHandler<CloseEventArgs> callback)
            : base(text)
        {
            Initialize(text, responseId);

            _closeHandler = callback;
        }

        private void OnClick(object sender, EventArgs args)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                _clickedMessage = btn.Label;

                if (_closeHandler == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(_clickedMessage) == true)
                {
                    return;
                }

                MessageResponse response;
                if (Enum.TryParse<MessageResponse>(_clickedMessage, out response) == true)
                {
                    responseType = response;

                    CloseEventArgs param = new CloseEventArgs(response);
                    _closeHandler(this, param);
                }

                this.Destroy();
            }
        }

        private void Initialize(string text, MessageResponse responseId)
        {
            SetDefaultSize(320, 240);
            SetPosition(WindowPosition.Center);

            vbox.PackStart(valign);

            Label label = new Label(text);
            label.SetAlignment(0.5f, 0);
            vbox.Add(label);

            switch (responseId)
            {
                case MessageResponse.Ok:
                    MakeButton("Ok");
                    break;
                case MessageResponse.Yes:
                    MakeButton("Yes");
                    break;
                case MessageResponse.OkCancel:
                    MakeButton("Ok");
                    MakeButton("Cancel");
                    break;
                case MessageResponse.YesNo:
                    MakeButton("Yes");
                    MakeButton("No");
                    break;

                default:
                    MakeButton("Ok");
                    break;
            }

            halign.Add(hbox);
            vbox.PackStart(halign, false, false, 3);

            Add(vbox);
        }

        private void MakeButton(string text)
        {
            Button btn = new Button(text);
            btn.SetSizeRequest(70, 30);
            btn.Clicked += OnClick;
            hbox.Add(btn);
        }

        public void Open()
        {
            this.ShowAll();
        }
    }
}

