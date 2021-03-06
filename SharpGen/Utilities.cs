﻿// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;

namespace SharpGen
{
    /// <summary>
    /// Utility class.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Escapes the xml/html text in order to use it inside xml.
        /// </summary>
        /// <param name="stringToEscape">The string to escape.</param>
        /// <returns></returns>
        public static string EscapeXml(string stringToEscape)
        {
            return stringToEscape.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");            
        }

        /// <summary>
        /// Gets a resource from this assembly.
        /// </summary>
        /// <param name="resourceName">The resource name.</param>
        /// <returns>The text of resource</returns>
        public static string GetResourceAsString(string resourceName)
        {
            Assembly asm = typeof(Utilities).GetTypeInfo().Assembly;

            string val = "";
            //' resources are named using a fully qualified name
            Stream strm = asm.GetManifestResourceStream(typeof (Utilities).Namespace + "." + resourceName);

            //' read the contents of the embedded file
            using (var reader = new StreamReader(strm))
                val = reader.ReadToEnd();

            return val;
        }
        
		/// <summary>
		/// Determines whether a string contains a given C++ identifier.
		/// </summary>
		/// <param name="str">The string to search.</param>
		/// <param name="identifier">The C++ identifier to search for.</param>
		/// <returns></returns>
		public static bool ContainsCppIdentifier(string str, string identifier)
		{
			if (string.IsNullOrEmpty(str))
				return string.IsNullOrEmpty(identifier);

			return Regex.IsMatch(str, string.Format(@"\b{0}\b", Regex.Escape(identifier)), RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
		}
    }
}