/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements. See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership. The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System.IO;

namespace Elasticsearch.Net.Connection.Thrift.Transport
{
	public class TBufferedTransport : TTransport
	{
		private readonly int bufSize;
		private readonly TStreamTransport transport;
		private BufferedStream inputBuffer;
		private BufferedStream outputBuffer;

		public TBufferedTransport(TStreamTransport transport)
			: this(transport, 1024)
		{
		}

		public TBufferedTransport(TStreamTransport transport, int bufSize)
		{
			this.bufSize = bufSize;
			this.transport = transport;
			InitBuffers();
		}

		public TTransport UnderlyingTransport
		{
			get { return transport; }
		}

		public override bool IsOpen
		{
			get { return transport.IsOpen; }
		}

		private void InitBuffers()
		{
			if (transport.InputStream != null)
			{
				inputBuffer = new BufferedStream(transport.InputStream, bufSize);
			}
			if (transport.OutputStream != null)
			{
				outputBuffer = new BufferedStream(transport.OutputStream, bufSize);
			}
		}

		public override void Open()
		{
			transport.Open();
			InitBuffers();
		}

		public override void Close()
		{
			if (inputBuffer != null && inputBuffer.CanRead)
			{
				inputBuffer.Close();
			}
			if (outputBuffer != null && outputBuffer.CanWrite)
			{
				outputBuffer.Close();
			}
			if (transport != null)
			{
				transport.Close();
			}
		}

		public override int Read(byte[] buf, int off, int len)
		{
			return inputBuffer.Read(buf, off, len);
		}

		public override void Write(byte[] buf, int off, int len)
		{
			outputBuffer.Write(buf, off, len);
		}

		public override void Flush()
		{
			outputBuffer.Flush();
		}
	}
}