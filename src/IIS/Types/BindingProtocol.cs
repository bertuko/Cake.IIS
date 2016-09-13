using System;

namespace Cake.IIS
{
    public sealed class BindingProtocol
    {
        public static BindingProtocol Ftp
        {
            get { return new BindingProtocol(Uri.UriSchemeFtp); }
        }

        public static BindingProtocol Http
        {
            get { return new BindingProtocol(Uri.UriSchemeHttp); }
        }

        public static BindingProtocol Https
        {
            get { return new BindingProtocol(Uri.UriSchemeHttps); }
        }

        public static BindingProtocol NetTcp
        {
            get { return new BindingProtocol(Uri.UriSchemeNetTcp); }
        }

        public static BindingProtocol NetPipe
        {
            get { return new BindingProtocol(Uri.UriSchemeNetPipe); }
        }

        public static BindingProtocol NetMsmq
        {
            get { return new BindingProtocol("net.msmq"); }
        }

        public static BindingProtocol MsmqFormatName
        {
            get { return new BindingProtocol("msmq.formatname"); }
        }

        private BindingProtocol(string name)
        {
            Name = name;
        }

        private string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        private bool Equals(BindingProtocol other)
        {
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is BindingProtocol && Equals((BindingProtocol)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
