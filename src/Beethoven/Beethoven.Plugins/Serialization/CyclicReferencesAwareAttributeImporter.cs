//------------------------------------------------------------------------------------------------------------------------------------
//  Hi!  There's a really good chance this code originated from http://www.sanderstechnology.com
//
//  Some of this code originated from publically accessible code, such code is so labelled.
//  This code is free to use & distribute, but please be aware that it is a sample product, and is not production quality.
//
//  If it helped you out, we'd really appreciate it if you'd check out the site and *ahem* clicked on some of the ads *wink*.
//  Please (if you can) try to leave this comment header, I can always do with some free advertising.
//  Should you need some help you can try emailing rob.sanders@gmail.com - no guarantees if I can get back to you in a timely fashion.
//  Regards, Rob
//------------------------------------------------------------------------------------------------------------------------------------

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.Web.Services.Description;
using System.Xml.Schema;
using System.Xml;
using System.CodeDom;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Collections.ObjectModel;
using System.Diagnostics;
#endregion

namespace Beethoven.Plugins.Serialization
{  
    /// <summary>
    /// Implements a WSDL Import Extension to write the CyclicReferencesAwareAttribute out to a generated WSDL source
    /// </summary>
    public class CyclicReferencesAwareAttributeImporter :
        IWsdlImportExtension,
        IServiceContractGenerationExtension,
        IOperationContractGenerationExtension,       
        IOperationBehavior        
    {
        #region WSDL Import

        public CyclicReferencesAwareAttributeImporter()
        {
        }   
        
        public void ImportContract(WsdlImporter importer, WsdlContractConversionContext context)
        { 
            // Operation Documentation
            foreach (Operation operation in context.WsdlPortType.Operations)
            {
                // Operations with the CyclicReferencesAwareAttribute should have a documentation item
                // See CyclicReferencesAwareAttribute::ExportContract for more info
                if (operation.Documentation != null && operation.Documentation == "CyclicReferencesAwareAttribute")
                {                         
                    OperationDescription operationDescription = context.Contract.Operations.Find(operation.Name);
                    if (operationDescription != null)
                    {
                        // System examines the operation behaviors to see whether any implement IWsdlImportExtension.
                        operationDescription.Behaviors.Add(new CyclicReferencesAwareAttributeImporter());
                    }
                }
            }
        }

        public void BeforeImport(ServiceDescriptionCollection wsdlDocuments, XmlSchemaSet xmlSchemas, ICollection<XmlElement> policy)
        {
        }

        public void ImportEndpoint(WsdlImporter importer, WsdlEndpointConversionContext context) 
        {            
        }

        #endregion

        #region Code Generation

        public void GenerateContract(ServiceContractGenerationContext context)
        {             
        }

        /// <summary>
        /// This is where we actually write the attribute out into the generated WSDL code
        /// </summary>
        /// <param name="context"></param>
        public void GenerateOperation(OperationContractGenerationContext context)
        {   
            context.SyncMethod.Comments.Add(new CodeCommentStatement("Set CyclicReferencesAware Attribute"));
            
            CodeAttributeArgument codeAttr = new CodeAttributeArgument( new CodePrimitiveExpression(true));
            context.SyncMethod.CustomAttributes.Add(new CodeAttributeDeclaration("CyclicReferencesAware", new CodeAttributeArgument[] { codeAttr }));
        }

        #endregion

        #region IOperationBehavior Members

        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
            return;
        }

        public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
        {
            return;
        }

        public void ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
        {
        }

        public void Validate(OperationDescription description)
        {
            return;
        }

        #endregion
    }
}
