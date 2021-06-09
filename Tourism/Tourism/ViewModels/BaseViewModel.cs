using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : FreshBasePageModel
    {
        public string Title { get; set; }
        public bool IsBusy { get; set; }

        protected virtual void Setup()
        {

        }

        public async override void Init(object initData)
        {
            //overriden to allow task based Initialize method
            base.Init(initData);
            await Initialize(initData);
        }

        public async override void ReverseInit(object returnedData)
        {
            //overriden to allow task based ReverseInitialize method
            base.ReverseInit(returnedData);
            await ReverseInitialize(returnedData);
        }

        public virtual Task Initialize(object initData)
        {
            return Task.CompletedTask;
        }

        public virtual Task ReverseInitialize(object returnedData)
        {
            return Task.CompletedTask;
        }
    }
}
