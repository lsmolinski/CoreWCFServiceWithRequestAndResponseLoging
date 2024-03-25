
using CoreWCF.Dispatcher;

namespace CoreWCFServiceWithRequestAndResponseLoging
{
    public class LoggingDispatchMessageInspector : IDispatchMessageInspector
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            log.Debug(request.ToString());
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            log.Debug(reply.ToString());
        }
    }
}