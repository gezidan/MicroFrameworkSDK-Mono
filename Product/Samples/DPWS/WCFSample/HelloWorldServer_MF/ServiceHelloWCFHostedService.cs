//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     .NET Micro Framework MFSvcUtil.Exe
//     Runtime Version:2.0.00001.0001
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Text;
using System.Xml;
using Dpws.Device;
using Dpws.Device.Services;
using Ws.Services;
using Ws.Services.WsaAddressing;
using Ws.Services.Xml;
using Ws.Services.Binding;
using Ws.Services.Mtom;
using Ws.Services.Soap;

namespace localhost.ServiceHelloWCF
{

    class HelloWCFService : DpwsHostedService
    {
        public HelloWCFService(ProtocolVersion v)
            : base(v)
        {
            // Add ServiceNamespace. Set ServiceID and ServiceTypeName
            ServiceNamespace = new WsXmlNamespace("h", "http://schemas.example.org/HelloWCF");
            ServiceID = "urn:uuid:3cb0d1ba-cc3a-46ce-b416-212ac2419b51";
            ServiceTypeName = "HelloWCFDeviceType";
        }

        public HelloWCFService()
            : this(new ProtocolVersion10())
        {
        }
    }
    
    public class IServiceHelloWCF : DpwsHostedService
    {
        
        private IIServiceHelloWCF m_service;
        
        public IServiceHelloWCF(IIServiceHelloWCF service, ProtocolVersion version) : 
                base(version)
        {
            // Set the service implementation properties
            m_service = service;

            // Set base service properties
            ServiceNamespace = new WsXmlNamespace("ise", "http://localhost/ServiceHelloWCF");
            ServiceID = "urn:uuid:f4c30207-c2cb-493c-8a44-776c1e0ecc7e";
            ServiceTypeName = "IServiceHelloWCF";

            // Add service types here
            ServiceOperations.Add(new WsServiceOperation("http://localhost/ServiceHelloWCF/IServiceHelloWCF", "HelloWCF"));

            // Add event sources here
        }
        
        public IServiceHelloWCF(IIServiceHelloWCF service) : 
                this(service, new ProtocolVersion10())
        {
        }
        
        public virtual WsMessage HelloWCF(WsMessage request)
        {
            // Build request object
            HelloWCFDataContractSerializer reqDcs;
            reqDcs = new HelloWCFDataContractSerializer("HelloWCF", "http://localhost/ServiceHelloWCF");
            HelloWCF req;
            req = ((HelloWCF)(reqDcs.ReadObject(request.Reader)));

            // Create response object
            // Call service operation to process request and return response.
            HelloWCFResponse resp;
            resp = m_service.HelloWCF(req);

            // Create response header
            WsWsaHeader respHeader = new WsWsaHeader("http://localhost/ServiceHelloWCF/IServiceHelloWCF/HelloWCFResponse", request.Header.MessageID, m_version.AnonymousUri, null, null, null);
            WsMessage response = new WsMessage(respHeader, resp, WsPrefix.Wsdp);

            // Create response serializer
            HelloWCFResponseDataContractSerializer respDcs;
            respDcs = new HelloWCFResponseDataContractSerializer("HelloWCFResponse", "http://localhost/ServiceHelloWCF");
            response.Serializer = respDcs;
            return response;
        }
    }
}
