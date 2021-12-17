using System;
using System.IO;
using System.Text;

namespace DecoratorStream
{
	public class DecoratorStream : Stream
	{
		private Stream stream;
		private string prefix;

		public override bool CanSeek { get { return false; } }
		public override bool CanWrite { get { return true; } }
		public override long Length { get; }
		public override long Position { get; set; }
		public override bool CanRead { get { return false; } }

		public DecoratorStream(Stream stream, string prefix) : base()
		{
			this.stream = stream;
			this.prefix = prefix;
			UTF8Encoding utf8 = new UTF8Encoding();
			byte[] utf8Encoding = utf8.GetBytes(prefix);
			this.Write(utf8Encoding, 0, utf8Encoding.Length);
	
		}

		public override void SetLength(long length)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] bytes, int offset, int count)
		{
			for(int i = offset; i < count; i++)
            {
				stream.WriteByte(bytes[i]);
            }
		}

		public override int Read(byte[] bytes, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void Flush()
		{
			stream.Flush();
		}

	}
	class Program
    {
        static void Main(string[] args)
        {
			byte[] message = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x2c, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64, 0x21 };
			using (MemoryStream stream = new MemoryStream())
			{
				using (DecoratorStream decoratorStream = new DecoratorStream(stream, "First line: "))
				{
					decoratorStream.Write(message, 0, message.Length);
					stream.Position = 0;
					Console.WriteLine(new StreamReader(stream).ReadLine());  //should print "First line: Hello, world!"
					Console.ReadLine();
				}
			}
		}
    }
}
