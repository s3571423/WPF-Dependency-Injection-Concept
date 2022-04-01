namespace DependencyInjectionConcept.Core.ViewModels
{
    public abstract class ViewModelBase : PropertyChangedNotification
    {
        /// <summary>
        /// Title of the View Model
        /// </summary>
        public string Title
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        protected ViewModelBase(string title)
        {
            Title = title;
        }
    }
}
