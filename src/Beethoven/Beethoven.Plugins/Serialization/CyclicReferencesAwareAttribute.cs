//
//  Source : http://chabster.blogspot.com/2008/02/wcf-cyclic-references-support.html
//  With some modifications

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Description;
using System.Diagnostics;
using System.Xml;
using System.Web.Services.Description;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Collections;
using System.CodeDom;

namespace Beethoven.Plugins.Serialization
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method)]
    public class CyclicReferencesAwareAttribute : Attribute, IContractBehavior, IOperationBehavior, IWsdlExportExtension                 
    {
        private readonly bool _on = true;
        private ContractDescription  _contractDescription;
        private OperationDescription _operationDescription;

        public CyclicReferencesAwareAttribute(bool on)
        {
            _on = on;
        }

        public CyclicReferencesAwareAttribute()
        {
            _on = true;
        }

        public bool On
        {
            get { return (_on); }
        }

        #region IOperationBehavior Members

        void IOperationBehavior.AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        void IOperationBehavior.ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(operationDescription, On);
        }

        void IOperationBehavior.ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            this._operationDescription = operationDescription;
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(operationDescription, On);
        }

        void IOperationBehavior.Validate(OperationDescription operationDescription)
        {
        }

        #endregion

        #region IContractBehavior Members

        void IContractBehavior.AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        void IContractBehavior.ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(contractDescription, On);
        }

        void IContractBehavior.ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
        {
            this._contractDescription = contractDescription;
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(contractDescription, On);
        }

        void IContractBehavior.Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        #endregion       
    
        /// <summary>
        /// When the contract is exported, we add "CyclicReferencesAwareAttribute" to the export so that the WSDL importer knows
        /// where to add the attribute on the client side.  Yes, I'll admit it's a little kludge, but it seems to work.
        /// </summary>
        /// <param name="exporter"></param>
        /// <param name="context"></param>
        public void ExportContract(WsdlExporter exporter, WsdlContractConversionContext context)
        {           
            if (_contractDescription != null)
            {
                context.WsdlPortType.Documentation = "CyclicReferencesAwareAttribute";
            }
            else
            {
                Operation operation = context.GetOperation(_operationDescription);
                if (operation != null)
                {
                    operation.Documentation = "CyclicReferencesAwareAttribute";
                }
            }
        }

        public void ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context)
        {            
        }
    }

}