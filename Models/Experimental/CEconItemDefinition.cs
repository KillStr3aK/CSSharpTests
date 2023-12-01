namespace CSSharpTests.Experimental
{
    using CounterStrikeSharp.API;

    public unsafe class CEconItemDefinition : NativeObject
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct CEconItemDefinitionLayout
        {
            [FieldOffset(0x8)]
            public void* m_pKVItem;

            [FieldOffset(0x10)]
            public ushort m_nDefIndex;

            // because it contains an object field at offset x that is incorrectly aligned or overlapped by a non-object field.
            [FieldOffset(0x12)]
            public /*CUtlVector<nint>*/void* m_nAssociatedItemsDefIndexes;

            [FieldOffset(0x15)]
            public bool m_bEnabled;

            [FieldOffset(0x16)]
            public IntPtr m_szPrefab;

            [FieldOffset(0x18)]
            public byte m_unMinItemLevel;

            [FieldOffset(0x19)]
            public byte m_unMaxItemLevel;

            [FieldOffset(0x1A)]
            public byte m_nItemRarity;

            [FieldOffset(0x1B)]
            public byte m_nItemQuality;

            [FieldOffset(0x1C)]
            public byte m_nForcedItemQuality;

            [FieldOffset(0x1D)]
            public byte m_nDefaultDropItemQuality;

            [FieldOffset(0x1E)]
            public byte m_nDefaultDropQuantity;

            // because it contains an object field at offset x that is incorrectly aligned or overlapped by a non-object field.
            [FieldOffset(0x20)]
            public /*CUtlVector<nint>*/void* m_vecStaticAttributes;

            [FieldOffset(0x28)]
            public byte m_nPopularitySeed;

            [FieldOffset(0x29)]
            public void* m_pPortraitsKV;

            [FieldOffset(0x30)]
            public IntPtr m_pszItemBaseName;

            [FieldOffset(0x38)]
            public bool m_bProperName;

            [FieldOffset(0x39)]
            public IntPtr m_pszItemTypeName;

            [FieldOffset(0x40)]
            public uint m_unItemTypeID;

            [FieldOffset(0x48)]
            public IntPtr m_pszItemDesc;
        }

        public CEconItemDefinitionLayout Value => Marshal.PtrToStructure<CEconItemDefinitionLayout>(this.Handle);

        public CEconItemDefinition(nint ptr) : base(ptr)
            { }

        public string GetModelName()
        {
            return Unsafe.Read<string>((void*)(this.Handle + 0xD8));
        }

        public string GetSimpleWeaponName()
        {
            return Unsafe.Read<string>((void*)(this.Handle + 0x210));
        }

        public int GetNumSupportedStickerSlots()
        {
            return Unsafe.Read<int>((void*)(this.Handle + 0x100));
        }

        public int GetLoadoutSlot()
        {
            return Unsafe.Read<int>((void*)(this.Handle + 0x2E8));
        }
    }
}
