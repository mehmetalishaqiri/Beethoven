using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml;
using System.Data.Objects;

namespace Beethoven.Plugins.Serialization
{
    public class ProxyDataContractResolver : DataContractResolver
    {
        private XsdDataContractExporter _exporter = new XsdDataContractExporter();

        public override Type ResolveName(
                               string typeName,
                               string typeNamespace,
                               Type declaredType,
                               DataContractResolver knownTypeResolver)
        {
            return knownTypeResolver.ResolveName(
                                       typeName, typeNamespace, declaredType, null);
        }

        public override bool TryResolveType(
                               Type dataContractType,
                               Type declaredType,
                               DataContractResolver knownTypeResolver,
                               out XmlDictionaryString typeName,
                               out XmlDictionaryString typeNamespace)
        {
            Type nonProxyType = ObjectContext.GetObjectType(dataContractType);
            if (nonProxyType != dataContractType)
            {
                // Type was a proxy type, so map the name to the non-proxy name
                XmlQualifiedName qualifiedName = _exporter.GetSchemaTypeName(nonProxyType);
                XmlDictionary dictionary = new XmlDictionary(2);
                typeName = new XmlDictionaryString(dictionary,
                                                   qualifiedName.Name, 0);
                typeNamespace = new XmlDictionaryString(dictionary,
                                                         qualifiedName.Namespace, 1);
                return true;
            }
            else
            {
                // Type was not a proxy type, so do the default
                return knownTypeResolver.TryResolveType(
                                          dataContractType,
                                          declaredType,
                                          null,
                                          out typeName,
                                          out typeNamespace);
            }
        }
    }
}