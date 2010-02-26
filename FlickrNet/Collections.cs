using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Collections.Generic;

namespace FlickrNet
{
	/// <remarks/>
	public class CollectionList : List<Collection>, IFlickrParsable
	{
        public void Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "collections")
                throw new FlickrException("Unknown element found: " + reader.LocalName);

            reader.Read();

            while (reader.LocalName == "collection")
            {
                Collection c = new Collection();
                c.Load(reader);
                Add(c);
            }

            // Skip to next element (if any)
            reader.Skip();

        }
    }


}
