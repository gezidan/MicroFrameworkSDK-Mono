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
using System.Xml;
using System.Ext;
using System.Ext.Xml;
using Ws.ServiceModel;
using Ws.Services.Mtom;
using Ws.Services.Serialization;
using XmlElement = Ws.Services.Xml.WsXmlNode;
using XmlAttribute = Ws.Services.Xml.WsXmlAttribute;
using XmlConvert = Ws.Services.Serialization.WsXmlConvert;

namespace schemas.example.org.EventingService
{
    
    
    [DataContract(Namespace="http://schemas.example.org/EventingService")]
    public class SimpleEventRequest
    {
    }
    
    public class SimpleEventRequestDataContractSerializer : DataContractSerializer
    {
        
        public SimpleEventRequestDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public SimpleEventRequestDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            SimpleEventRequest SimpleEventRequestField = null;
            if (IsParentStartElement(reader, false, true))
            {
                SimpleEventRequestField = new SimpleEventRequest();
                reader.Read();
                reader.ReadEndElement();
            }
            return SimpleEventRequestField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            SimpleEventRequest SimpleEventRequestField = ((SimpleEventRequest)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                writer.WriteEndElement();
            }
            return;
        }
    }
    
    [DataContract(Namespace="http://schemas.example.org/EventingService")]
    public class IntegerEventRequest
    {
        
        [DataMember(Order=0, IsNillable=true)]
        public int Param;
        
        [DataMember(IsNillable=true, IsRequired=false)]
        public XmlElement[] Any;
        
        [DataMember(IsNillable=true, IsRequired=false)]
        public XmlAttribute[] AnyAttr;
    }
    
    public class IntegerEventRequestDataContractSerializer : DataContractSerializer
    {
        
        public IntegerEventRequestDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public IntegerEventRequestDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            IntegerEventRequest IntegerEventRequestField = null;
            if (IsParentStartElement(reader, false, true))
            {
                IntegerEventRequestField = new IntegerEventRequest();
                IntegerEventRequestField.AnyAttr = ReadAnyAttribute(reader);
                reader.Read();
                if (IsChildStartElement(reader, "Param", true, true))
                {
                    reader.Read();
                    IntegerEventRequestField.Param = XmlConvert.ToInt32(reader.ReadString());
                    reader.ReadEndElement();
                }
                IntegerEventRequestField.Any = ReadAnyElement(reader, false);
                reader.ReadEndElement();
            }
            return IntegerEventRequestField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            IntegerEventRequest IntegerEventRequestField = ((IntegerEventRequest)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                WriteAnyAttribute(writer, IntegerEventRequestField.AnyAttr);
                if (WriteChildElement(writer, "Param", true, true, IntegerEventRequestField.Param))
                {
                    writer.WriteString(XmlConvert.ToString(IntegerEventRequestField.Param));
                    writer.WriteEndElement();
                }
                WriteAnyElement(writer, IntegerEventRequestField.Any, false);
                writer.WriteEndElement();
            }
            return;
        }
    }
    
    [ServiceContract(Namespace="http://schemas.example.org/EventingService", CallbackContract=typeof(IEventingServiceCallback))]
    [PolicyAssertion(Namespace="http://schemas.xmlsoap.org/ws/2006/02/devprof", Name="profile", PolicyID="EventingServicePolicy")]
    [PolicyAssertion(Namespace="http://schemas.xmlsoap.org/ws/2006/02/devprof", Name="PushDelivery", PolicyID="EventingServicePolicy")]
    [PolicyAssertion(Namespace="http://schemas.xmlsoap.org/ws/2006/02/devprof", Name="DurationExpiration", PolicyID="EventingServicePolicy")]
    [PolicyAssertion(Namespace="http://schemas.xmlsoap.org/ws/2006/02/devprof", Name="ActionFilter", PolicyID="EventingServicePolicy")]
    public interface IEventingService
    {
    }
    
    public interface IEventingServiceCallback
    {
        
        [OperationContract(Action="http://schemas.example.org/EventingService/SimpleEvent")]
        void SimpleEvent(SimpleEventRequest resp);
        
        [OperationContract(Action="http://schemas.example.org/EventingService/IntegerEvent")]
        void IntegerEvent(IntegerEventRequest resp);
    }
}
