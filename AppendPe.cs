using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PEConstr {
	public partial class Form1: Form {
		public byte[] peHeader = {
			0x4D, 0x5A, 0x80, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x10, 0x00, 0xFF, 0xFF, 0x00, 0x00,
			0x40, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00,
			0x0E, 0x1F, 0xBA, 0x0E, 0x00, 0xB4, 0x09, 0xCD, 0x21, 0xB8, 0x01, 0x4C, 0xCD, 0x21, 0x54, 0x68,
			0x69, 0x73, 0x20, 0x70, 0x72, 0x6F, 0x67, 0x72, 0x61, 0x6D, 0x20, 0x63, 0x61, 0x6E, 0x6E, 0x6F,
			0x74, 0x20, 0x62, 0x65, 0x20, 0x72, 0x75, 0x6E, 0x20, 0x69, 0x6E, 0x20, 0x44, 0x4F, 0x53, 0x20,
			0x6D, 0x6F, 0x64, 0x65, 0x2E, 0x0D, 0x0A, 0x24, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x50, 0x45, 0x00, 0x00, 0x4C, 0x01, 0x03, 0x00, 0xE8, 0x70, 0x43, 0x56, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0xE0, 0x00, 0x0F, 0x01, 0x0B, 0x01, 0x01, 0x47, 0x00, 0x02, 0x00, 0x00,
			0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00,
			0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00,
			0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x40, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00,
			0x00, 0x10, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x30, 0x00, 0x00, 0x92, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
		};
		public byte[] sectionHeader = {
			0x2E, 0x74, 0x65, 0x78, 0x74, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00,
			0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x20, 0x2E, 0x72, 0x64, 0x61, 0x74, 0x61, 0x00, 0x00,
			0x0E, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x40,
			0x2E, 0x69, 0x64, 0x61, 0x74, 0x61, 0x00, 0x00, 0x92, 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x00,
			0x00, 0x02, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
		};


		public byte[] text = {
			0x68, 0x00, 0x20, 0x40, 0x00, 0xFF, 0x15, 0x80, 0x30, 0x40, 0x00, 0x6A, 0x00, 0xFF, 0x15, 0x60, 0x30, 0x40, 0x00,
		};

		public byte[] rdata = {
			0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x77, 0x6F, 0x72, 0x6C, 0x64, 0x21, 0x0A, 0x00,
		};

		public byte[] idata = {
			0x58, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3C, 0x30, 0x00, 0x00,
			0x60, 0x30, 0x00, 0x00, 0x78, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x4A, 0x30, 0x00, 0x00, 0x80, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6B, 0x65, 0x72, 0x6E,
			0x65, 0x6C, 0x33, 0x32, 0x2E, 0x64, 0x6C, 0x6C, 0x00, 0x00, 0x6D, 0x73, 0x76, 0x63, 0x72, 0x74,
			0x2E, 0x64, 0x6C, 0x6C, 0x00, 0x00, 0x00, 0x00, 0x68, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x68, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x45, 0x78, 0x69, 0x74, 0x50, 0x72,
			0x6F, 0x63, 0x65, 0x73, 0x73, 0x00, 0x00, 0x00, 0x88, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x88, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x72, 0x69, 0x6E, 0x74, 0x66,
			0x00,
		};


		public Form1() {
			InitializeComponent();
		}

		void SetSizeOfCode(uint param) {
			peHeader[159] = (byte)((param >> 24) & 0xFF);
			peHeader[158] = (byte)((param >> 16) & 0xFF);
			peHeader[157] = (byte)((param >> 8) & 0xFF);
			peHeader[156] = (byte)(param & 0xFF);
		}

		void SetTextVirtualSize() {
			uint len = (uint) text.Length;
			sectionHeader[11] = (byte)((len >> 24) & 0xFF);
			sectionHeader[10] = (byte)((len >> 16) & 0xFF);
			sectionHeader[9] = (byte)((len >> 8) & 0xFF);
			sectionHeader[8] = (byte)(len & 0xFF);
		}

		void SetTextRawSize() {
			uint size = uint.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
			sectionHeader[19] = (byte)((size >> 24) & 0xFF);
			sectionHeader[18] = (byte)((size >> 16) & 0xFF);
			sectionHeader[17] = (byte)((size >> 8) & 0xFF);
			sectionHeader[16] = (byte)(size & 0xFF);
		}

		void SetRdataRawPtr() {
			uint size = uint.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowHexSpecifier) + 0x200;
			sectionHeader[63] = (byte)((size >> 24) & 0xFF);
			sectionHeader[62] = (byte)((size >> 16) & 0xFF);
			sectionHeader[61] = (byte)((size >> 8) & 0xFF);
			sectionHeader[60] = (byte)(size & 0xFF);
		}

		void SetIdataRawPtr() {
			uint size = uint.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowHexSpecifier) + 0x400;
			sectionHeader[103] = (byte)((size >> 24) & 0xFF);
			sectionHeader[102] = (byte)((size >> 16) & 0xFF);
			sectionHeader[101] = (byte)((size >> 8) & 0xFF);
			sectionHeader[100] = (byte)(size & 0xFF);
		}

		void SavePe() {
			SetSizeOfCode(uint.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowHexSpecifier));
			SetTextVirtualSize();
			SetTextRawSize();
			SetRdataRawPtr();
			SetIdataRawPtr();
			FileStream fs = new FileStream("prog.exe", FileMode.OpenOrCreate, FileAccess.Write);
			using(BinaryWriter w = new BinaryWriter(fs)) {
				for (int i = 0; i < peHeader.Length; i++)
				w.Write(peHeader[i]);

				for (int i = 0; i < sectionHeader.Length; i++)
				w.Write(sectionHeader[i]);

				int len = int.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowHexSpecifier) - text.Length;
				byte[] b = new byte[len];
				b.Initialize();

				for (int i = 0; i < text.Length; i++) {
					w.Write(text[i]);
				}

				for (int i = 0; i < len; i++) {
					w.Write(b[i]);
				}

				len = 0x200 - rdata.Length;
				b = new byte[len];
				b.Initialize();
				for (int i = 0; i < rdata.Length; i++) {
					w.Write(rdata[i]);
				}
				for (int i = 0; i < b.Length; i++) {
					w.Write(b[i]);
				}
				len = 0x200 - idata.Length;
				b = new byte[len];
				b.Initialize();
				for (int i = 0; i < idata.Length; i++) {
					w.Write(idata[i]);
				}
				for (int i = 0; i < b.Length; i++) {
					w.Write(b[i]);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			SavePe();
		}

	}
}
