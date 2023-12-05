using System.Windows.Controls;
using UI.ViewModels;

namespace UI.Helpers
{
    public class TextBoxHelper
    {
        public static void HandleValidation(object sender, BaseViewModel viewModel, ValidationErrorEventArgs e)
        {
            var textBox = (TextBox)sender;

            var bindingName = textBox.GetBindingExpression(TextBox.TextProperty).ParentBinding.Path.Path;

            string errorMessage;

            if (e.Error.Exception != null)
            {
                errorMessage = "Заполните поле";
            }
            else
            {
                errorMessage = e.Error.ErrorContent.ToString();
            }

            viewModel.RootViewModel.HandleError(viewModel.Guid, bindingName, errorMessage, e.Action);
        }
    }
}
