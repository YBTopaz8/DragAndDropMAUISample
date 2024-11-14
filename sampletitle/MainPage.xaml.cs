using System.Diagnostics;

namespace sampletitle
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        string filePath = string.Empty;
        private async void DropGestureRecognizer_DragOver(object sender, DragEventArgs e)
        {
#if WINDOWS
            var WindowsDragEventArgs = e.PlatformArgs.DragEventArgs;
            var dragUI = WindowsDragEventArgs.DragUIOverride;

            var DraggedOverItems = await WindowsDragEventArgs.DataView.GetStorageItemsAsync();
            e.AcceptedOperation = DataPackageOperation.None;

            if (DraggedOverItems.Count > 0)
            {
                foreach (var item in DraggedOverItems)
                {
                    if (item is Windows.Storage.StorageFile file)
                    {
                        string fileExtension = file.FileType.ToLower();
                        if(fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png")
                        {

                            dragUI.Caption = "Drop the file!";
                            dragUI.IsCaptionVisible = false;
                            dragUI.IsGlyphVisible = false;
                            
                            filePath = file.Path;
                            Debug.WriteLine($"We now have file {file.Path} dragged over!");
                        }
                        else
                        {
                            dragUI.Caption = "Invalid file type";
                            dragUI.IsCaptionVisible = true;
                            dragUI.IsGlyphVisible = false;
                            
                        }
                    }
                }
            }
#endif
        }
        private void DropGestureRecognizer_DragLeave(object sender, DragEventArgs e)
        {
            
        }

        private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {

            FileDropImage.Source = filePath;
        }
    }

}
