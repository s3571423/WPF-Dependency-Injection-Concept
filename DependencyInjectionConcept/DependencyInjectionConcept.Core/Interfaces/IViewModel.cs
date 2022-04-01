namespace DependencyInjectionConcept.Core.Interfaces
{
    public interface IViewModel<out TViewModel> where TViewModel : class
    {
        TViewModel Create();
    }

    public interface IViewModel<out TViewModel, in TParameter> where TViewModel : class
    {
        TViewModel Create(TParameter parameter);
    }

    public interface IViewModel<out TViewModel, in TParameter1, in TParameter2> where TViewModel : class
    {
        TViewModel Create(TParameter1 parameter1, TParameter2 parameter2);
    }

    public interface IViewModel<out TViewModel, in TParameter1, in TParameter2, in TParameter3> where TViewModel : class
    {
        TViewModel Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3);
    }

    public interface IViewModel<out TViewModel, in TParameter1, in TParameter2, in TParameter3, in TParameter4> where TViewModel : class
    {
        TViewModel Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3, TParameter4 parameter4);
    }

    public interface IViewModel<out TViewModel, in TParameter1, in TParameter2, in TParameter3, in TParameter4, in TParameter5> where TViewModel : class
    {
        TViewModel Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3, TParameter4 parameter4, TParameter5 parameter5);
    }
}
