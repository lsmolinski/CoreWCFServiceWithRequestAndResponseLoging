using CoreWCF.Description;
using CoreWCF.Dispatcher;
using Microsoft.AspNetCore.Authorization;
using System.Collections.ObjectModel;

namespace CoreWCFServiceWithRequestAndResponseLoging
{
    public class LogingRequestAndResponseServiceBehavior : IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            //nop
        }

        public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher eDispatcher in cDispatcher.Endpoints)
                {
                    eDispatcher.DispatchRuntime.MessageInspectors.Add(new LoggingDispatchMessageInspector());
                }
            }

        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            //noop
        }
    }
}