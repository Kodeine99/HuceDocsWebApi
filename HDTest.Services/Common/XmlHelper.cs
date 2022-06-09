using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HuceDocs.Services.Common
{
    public static class XmlHelper
    {
        public static void FCXmlToDynamicObj(IDictionary<string, object> parent, XElement node)
        {
            IEnumerable<XElement> elements = node.Elements();
            bool breakCondition = false;
            if (node.HasElements)
            {
                int nodeCount = node.Elements().Count();

                if (nodeCount > 0)
                {
                    // element is field vs in Children
                    if (node.Name.LocalName == "Field" && node.Parent != null && node.Parent.Name.LocalName == "Children")
                    {
                        var propertyName = string.Empty;
                        var propertyValue = string.Empty;
                        bool isHidden = false;
                        foreach (var attribute in node.Attributes())
                        {
                            if (attribute.Name == "Name")
                                propertyName = attribute.Value.Trim();
                            // check ishidden
                            if (attribute.Name == "IsHidden" && attribute.Value.Trim() == "true")
                                isHidden = true;
                        }

                        if (!isHidden)
                        {
                            foreach (var element in elements)
                            {
                                if (element.Name.LocalName == "TextValue")
                                {
                                    foreach (var attribute in element.Attributes())
                                    {
                                        if (attribute.Name == "Text")
                                            propertyValue = attribute.Value.Trim();
                                    }
                                }
                                if (element.Name.LocalName == "BooleanValue")
                                {
                                    foreach (var attribute in element.Attributes())
                                    {
                                        if (attribute.Name == "Value")
                                            propertyValue = attribute.Value.Trim();
                                    }
                                }
                                if (element.Name.LocalName == "Children")
                                {
                                    if (!string.IsNullOrWhiteSpace(propertyName))
                                    {
                                        AddProperty(parent, propertyName, propertyValue);
                                        parent[propertyName] = new System.Dynamic.ExpandoObject();
                                        FCXmlToDynamicObj((IDictionary<string, object>)parent[propertyName], element);
                                        breakCondition = true;
                                    }
                                }

                            }

                            if (!breakCondition && !string.IsNullOrWhiteSpace(propertyName))
                                AddProperty(parent, propertyName, propertyValue);
                        }
                    }
                    else
                    {
                        foreach (var element in elements)
                        {
                            FCXmlToDynamicObj(parent, element);
                        }
                    }
                }
            }
        }

        private static void AddProperty(dynamic parent, string name, object value)
        {
            ((IDictionary<string, object>)parent)[name] = value;
        }
        private static void AddProperty(dynamic parent, dynamic nextParent, string name, object value)
        {
            ((IDictionary<string, object>)parent)[name] = (((IDictionary<string, object>)nextParent)[name] = value);
        }
    }
}
