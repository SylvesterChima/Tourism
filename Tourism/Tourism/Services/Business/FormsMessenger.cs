﻿using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;
using Xamarin.Forms;

namespace Tourism.Services.Business
{
    public class FormsMessenger : IMessenger
    {
        public void Send<TMessage>(TMessage message, object sender = null) where TMessage : IMessage
        {
            if (sender == null)
                sender = new object();

            MessagingCenter.Send<object, TMessage>(sender, typeof(TMessage).FullName, message);
        }

        public void Subscribe<TMessage>(object subscriber, Action<object, TMessage> callback) where TMessage : IMessage
        {
            MessagingCenter.Subscribe<object, TMessage>(subscriber, typeof(TMessage).FullName, callback, null);
        }

        public void Unsubscribe<TMessage>(object subscriber) where TMessage : IMessage
        {
            MessagingCenter.Unsubscribe<object, TMessage>(subscriber, typeof(TMessage).FullName);
        }
    }
}
