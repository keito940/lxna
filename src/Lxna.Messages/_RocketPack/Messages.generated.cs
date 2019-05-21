﻿
#nullable enable

namespace Lxna.Messages
{
    public enum LxnaContentType : byte
    {
        Directory = 0,
        Archive = 1,
        File = 2,
    }

    public enum LxnaThumbnailResizeType : byte
    {
        Pad = 0,
        Crop = 1,
    }

    public enum LxnaThumbnailFormatType : byte
    {
        Png = 0,
    }

    public sealed partial class LxnaOptions : Omnix.Serialization.RocketPack.RocketPackMessageBase<LxnaOptions>
    {
        static LxnaOptions()
        {
            LxnaOptions.Formatter = new CustomFormatter();
            LxnaOptions.Empty = new LxnaOptions(string.Empty);
        }

        private readonly int __hashCode;

        public static readonly int MaxConfigDirectoryPathLength = 1024;

        public LxnaOptions(string configDirectoryPath)
        {
            if (configDirectoryPath is null) throw new System.ArgumentNullException("configDirectoryPath");
            if (configDirectoryPath.Length > 1024) throw new System.ArgumentOutOfRangeException("configDirectoryPath");

            this.ConfigDirectoryPath = configDirectoryPath;

            {
                var __h = new System.HashCode();
                if (this.ConfigDirectoryPath != default) __h.Add(this.ConfigDirectoryPath.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public string ConfigDirectoryPath { get; }

        public override bool Equals(LxnaOptions? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.ConfigDirectoryPath != target.ConfigDirectoryPath) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<LxnaOptions>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, LxnaOptions value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.ConfigDirectoryPath != string.Empty)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.ConfigDirectoryPath != string.Empty)
                {
                    w.Write((uint)0);
                    w.Write(value.ConfigDirectoryPath);
                }
            }

            public LxnaOptions Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                string p_configDirectoryPath = string.Empty;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // ConfigDirectoryPath
                            {
                                p_configDirectoryPath = r.GetString(1024);
                                break;
                            }
                    }
                }

                return new LxnaOptions(p_configDirectoryPath);
            }
        }
    }

    public sealed partial class LxnaContentId : Omnix.Serialization.RocketPack.RocketPackMessageBase<LxnaContentId>
    {
        static LxnaContentId()
        {
            LxnaContentId.Formatter = new CustomFormatter();
            LxnaContentId.Empty = new LxnaContentId((LxnaContentType)0, string.Empty);
        }

        private readonly int __hashCode;

        public static readonly int MaxPathLength = 1024;

        public LxnaContentId(LxnaContentType type, string path)
        {
            if (path is null) throw new System.ArgumentNullException("path");
            if (path.Length > 1024) throw new System.ArgumentOutOfRangeException("path");

            this.Type = type;
            this.Path = path;

            {
                var __h = new System.HashCode();
                if (this.Type != default) __h.Add(this.Type.GetHashCode());
                if (this.Path != default) __h.Add(this.Path.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public LxnaContentType Type { get; }
        public string Path { get; }

        public override bool Equals(LxnaContentId? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Type != target.Type) return false;
            if (this.Path != target.Path) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<LxnaContentId>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, LxnaContentId value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Type != (LxnaContentType)0)
                    {
                        propertyCount++;
                    }
                    if (value.Path != string.Empty)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Type != (LxnaContentType)0)
                {
                    w.Write((uint)0);
                    w.Write((ulong)value.Type);
                }
                if (value.Path != string.Empty)
                {
                    w.Write((uint)1);
                    w.Write(value.Path);
                }
            }

            public LxnaContentId Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                LxnaContentType p_type = (LxnaContentType)0;
                string p_path = string.Empty;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // Type
                            {
                                p_type = (LxnaContentType)r.GetUInt64();
                                break;
                            }
                        case 1: // Path
                            {
                                p_path = r.GetString(1024);
                                break;
                            }
                    }
                }

                return new LxnaContentId(p_type, p_path);
            }
        }
    }

    public sealed partial class LxnaThumbnail : Omnix.Serialization.RocketPack.RocketPackMessageBase<LxnaThumbnail>, System.IDisposable
    {
        static LxnaThumbnail()
        {
            LxnaThumbnail.Formatter = new CustomFormatter();
            LxnaThumbnail.Empty = new LxnaThumbnail(Omnix.Base.SimpleMemoryOwner<byte>.Empty);
        }

        private readonly int __hashCode;

        public static readonly int MaxValueLength = 33554432;

        public LxnaThumbnail(System.Buffers.IMemoryOwner<byte> value)
        {
            if (value is null) throw new System.ArgumentNullException("value");
            if (value.Memory.Length > 33554432) throw new System.ArgumentOutOfRangeException("value");

            _value = value;

            {
                var __h = new System.HashCode();
                if (!this.Value.IsEmpty) __h.Add(Omnix.Base.Helpers.ObjectHelper.GetHashCode(this.Value.Span));
                __hashCode = __h.ToHashCode();
            }
        }

        private readonly System.Buffers.IMemoryOwner<byte> _value;
        public System.ReadOnlyMemory<byte> Value => _value.Memory;

        public override bool Equals(LxnaThumbnail? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!Omnix.Base.BytesOperations.SequenceEqual(this.Value.Span, target.Value.Span)) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        public void Dispose()
        {
            _value?.Dispose();
        }

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<LxnaThumbnail>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, LxnaThumbnail value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (!value.Value.IsEmpty)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (!value.Value.IsEmpty)
                {
                    w.Write((uint)0);
                    w.Write(value.Value.Span);
                }
            }

            public LxnaThumbnail Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                System.Buffers.IMemoryOwner<byte> p_value = Omnix.Base.SimpleMemoryOwner<byte>.Empty;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // Value
                            {
                                p_value = r.GetRecyclableMemory(33554432);
                                break;
                            }
                    }
                }

                return new LxnaThumbnail(p_value);
            }
        }
    }

}