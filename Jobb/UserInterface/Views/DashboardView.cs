using System.Reactive.Disposables;
using System.Runtime.Serialization;
using Jobb.UserInterface.ViewModels;
using Terminal.Gui;
using ReactiveUI;

namespace Jobb.UserInterface.Views
{
    [DataContract]
    public class DashboardView : Window, IViewFor<DashboardViewModel>
    {
        #region Properties
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        #endregion
        
        #region Accessor/Modifier
        public DashboardViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DashboardViewModel) value;
        }
        #endregion

        #region Constructor
        public DashboardView(DashboardViewModel viewModel) : base("Dashboard")
        {
            ViewModel = viewModel;
            var jobbList = JobbList();
        }
        #endregion

        #region Worker
        protected override void Dispose(bool disposing)
        {
            _disposable.Dispose();
            base.Dispose(disposing);
        }
        
        
        #endregion

        #region Controls

        ListView JobbList()
        {
            // TODO: Put in the list of available jobbs.
            var jobbList = new ListView()
            {
                X = Pos.Left(this),
                Y = Pos.Top(this),
                Width = 40
            };
            // ViewModel
            //     .WhenAnyValue(x => x.ShowProperties)
            //     .BindTo(jobbList, x.ShowProperties)
            //     .DisposeWith(_disposable)
            // jobbList
            //     .Events()
            //     .SelectionChanged
            //     .InvokeCommand(ViewModel, x => x.ShowProperties)
            //     .DisposeWith(_disposable);
            Add(jobbList);
            return jobbList;
        }

        Label JobbPropertiesLabel(View previous)
        {
            var jobbPropertiesLabel = new Label()
            {
                X = Pos.Left(previous),
                Y = Pos.Top(previous) + 1,
                Width = 40
            };
            ViewModel
                .WhenAnyValue(x => x.PropertyNames)
                .BindTo(jobbPropertiesLabel, x => x.Text)
                .DisposeWith(_disposable);
        }
        
        
        
        #endregion
        
        

        
    }


}