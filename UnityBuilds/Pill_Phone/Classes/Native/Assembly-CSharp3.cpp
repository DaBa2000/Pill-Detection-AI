#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename T1>
struct VirtActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct VirtActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct GenericVirtActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct GenericVirtActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct GenericInterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct GenericInterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

// System.Byte[]
struct ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726;
// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;
// System.Delegate[]
struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8;
// System.Object[]
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE;
// System.AsyncCallback
struct AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA;
// UnityEngine.AudioClip
struct AudioClip_t16D2E573E7CC1C5118D8EE0F0692D46866A1C0EE;
// UnityEngine.AudioSource
struct AudioSource_tC4BF65AF8CDCAA63724BB3CA59A7A29249269E6B;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288;
// System.IAsyncResult
struct IAsyncResult_tC9F97BF36FCF122D29D3101D80642278297BF370;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// agora_gaming_rtc.OnSDKWarningHandler
struct OnSDKWarningHandler_tCF7C48612B64A29E23CA1F06356205D8E9C17980;
// Sound
struct Sound_tF983595F9C621A86B56E05F9778810369E90A0FE;
// System.String
struct String_t;
// agora_gaming_rtc.VideoFrame
struct VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E;
// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5;
// SoundManagement/<>c__DisplayClass2_0
struct U3CU3Ec__DisplayClass2_0_t6F378E20D5918FF686AF22D61F6E24B85BA63671;
// TestHelloUnityVideo/<>c
struct U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE;
// agora_gaming_rtc.VideoRawDataManager/OnCaptureVideoFrameHandler
struct OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510;
// agora_gaming_rtc.VideoRawDataManager/OnRenderVideoFrameHandler
struct OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7;

IL2CPP_EXTERN_C RuntimeClass* Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IRtcEngine_tAAB918008B7BD39030805371269AB0D499C5F647_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt32_tE60352A06233E4E69DD198BCC67142159F686B15_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral5B2855F5FF0FDAD6557B888B208FF0AE17AA3ED2;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E;;
struct VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke;
struct VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke;;

struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8;
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

struct Il2CppArrayBounds;

// System.Array


// Sound
struct Sound_tF983595F9C621A86B56E05F9778810369E90A0FE  : public RuntimeObject
{
public:
	// UnityEngine.AudioClip Sound::clip
	AudioClip_t16D2E573E7CC1C5118D8EE0F0692D46866A1C0EE * ___clip_0;
	// System.String Sound::name
	String_t* ___name_1;
	// UnityEngine.AudioSource Sound::source
	AudioSource_tC4BF65AF8CDCAA63724BB3CA59A7A29249269E6B * ___source_2;

public:
	inline static int32_t get_offset_of_clip_0() { return static_cast<int32_t>(offsetof(Sound_tF983595F9C621A86B56E05F9778810369E90A0FE, ___clip_0)); }
	inline AudioClip_t16D2E573E7CC1C5118D8EE0F0692D46866A1C0EE * get_clip_0() const { return ___clip_0; }
	inline AudioClip_t16D2E573E7CC1C5118D8EE0F0692D46866A1C0EE ** get_address_of_clip_0() { return &___clip_0; }
	inline void set_clip_0(AudioClip_t16D2E573E7CC1C5118D8EE0F0692D46866A1C0EE * value)
	{
		___clip_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___clip_0), (void*)value);
	}

	inline static int32_t get_offset_of_name_1() { return static_cast<int32_t>(offsetof(Sound_tF983595F9C621A86B56E05F9778810369E90A0FE, ___name_1)); }
	inline String_t* get_name_1() const { return ___name_1; }
	inline String_t** get_address_of_name_1() { return &___name_1; }
	inline void set_name_1(String_t* value)
	{
		___name_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___name_1), (void*)value);
	}

	inline static int32_t get_offset_of_source_2() { return static_cast<int32_t>(offsetof(Sound_tF983595F9C621A86B56E05F9778810369E90A0FE, ___source_2)); }
	inline AudioSource_tC4BF65AF8CDCAA63724BB3CA59A7A29249269E6B * get_source_2() const { return ___source_2; }
	inline AudioSource_tC4BF65AF8CDCAA63724BB3CA59A7A29249269E6B ** get_address_of_source_2() { return &___source_2; }
	inline void set_source_2(AudioSource_tC4BF65AF8CDCAA63724BB3CA59A7A29249269E6B * value)
	{
		___source_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___source_2), (void*)value);
	}
};


// System.String
struct String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Empty_5), (void*)value);
	}
};


// System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_com
{
};

// SoundManagement/<>c__DisplayClass2_0
struct U3CU3Ec__DisplayClass2_0_t6F378E20D5918FF686AF22D61F6E24B85BA63671  : public RuntimeObject
{
public:
	// System.String SoundManagement/<>c__DisplayClass2_0::name
	String_t* ___name_0;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(U3CU3Ec__DisplayClass2_0_t6F378E20D5918FF686AF22D61F6E24B85BA63671, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___name_0), (void*)value);
	}
};


// TestHelloUnityVideo/<>c
struct U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE  : public RuntimeObject
{
public:

public:
};

struct U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_StaticFields
{
public:
	// TestHelloUnityVideo/<>c TestHelloUnityVideo/<>c::<>9
	U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE * ___U3CU3E9_0;
	// agora_gaming_rtc.OnSDKWarningHandler TestHelloUnityVideo/<>c::<>9__3_0
	OnSDKWarningHandler_tCF7C48612B64A29E23CA1F06356205D8E9C17980 * ___U3CU3E9__3_0_1;

public:
	inline static int32_t get_offset_of_U3CU3E9_0() { return static_cast<int32_t>(offsetof(U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_StaticFields, ___U3CU3E9_0)); }
	inline U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE * get_U3CU3E9_0() const { return ___U3CU3E9_0; }
	inline U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE ** get_address_of_U3CU3E9_0() { return &___U3CU3E9_0; }
	inline void set_U3CU3E9_0(U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE * value)
	{
		___U3CU3E9_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CU3E9_0), (void*)value);
	}

	inline static int32_t get_offset_of_U3CU3E9__3_0_1() { return static_cast<int32_t>(offsetof(U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_StaticFields, ___U3CU3E9__3_0_1)); }
	inline OnSDKWarningHandler_tCF7C48612B64A29E23CA1F06356205D8E9C17980 * get_U3CU3E9__3_0_1() const { return ___U3CU3E9__3_0_1; }
	inline OnSDKWarningHandler_tCF7C48612B64A29E23CA1F06356205D8E9C17980 ** get_address_of_U3CU3E9__3_0_1() { return &___U3CU3E9__3_0_1; }
	inline void set_U3CU3E9__3_0_1(OnSDKWarningHandler_tCF7C48612B64A29E23CA1F06356205D8E9C17980 * value)
	{
		___U3CU3E9__3_0_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CU3E9__3_0_1), (void*)value);
	}
};


// System.Boolean
struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37, ___m_value_0)); }
	inline bool get_m_value_0() const { return ___m_value_0; }
	inline bool* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(bool value)
	{
		___m_value_0 = value;
	}
};

struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields
{
public:
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;

public:
	inline static int32_t get_offset_of_TrueString_5() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___TrueString_5)); }
	inline String_t* get_TrueString_5() const { return ___TrueString_5; }
	inline String_t** get_address_of_TrueString_5() { return &___TrueString_5; }
	inline void set_TrueString_5(String_t* value)
	{
		___TrueString_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TrueString_5), (void*)value);
	}

	inline static int32_t get_offset_of_FalseString_6() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___FalseString_6)); }
	inline String_t* get_FalseString_6() const { return ___FalseString_6; }
	inline String_t** get_address_of_FalseString_6() { return &___FalseString_6; }
	inline void set_FalseString_6(String_t* value)
	{
		___FalseString_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FalseString_6), (void*)value);
	}
};


// System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA  : public ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52
{
public:

public:
};

struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___enumSeperatorCharArray_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_com
{
};

// System.Int32
struct Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046, ___m_value_0)); }
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};


// System.IntPtr
struct IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};


// System.UInt32
struct UInt32_tE60352A06233E4E69DD198BCC67142159F686B15 
{
public:
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(UInt32_tE60352A06233E4E69DD198BCC67142159F686B15, ___m_value_0)); }
	inline uint32_t get_m_value_0() const { return ___m_value_0; }
	inline uint32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint32_t value)
	{
		___m_value_0 = value;
	}
};


// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5__padding[1];
	};

public:
};


// System.Delegate
struct Delegate_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_7;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_8;
	// System.DelegateData System.Delegate::data
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_10;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_target_2), (void*)value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_extra_arg_5() { return static_cast<int32_t>(offsetof(Delegate_t, ___extra_arg_5)); }
	inline intptr_t get_extra_arg_5() const { return ___extra_arg_5; }
	inline intptr_t* get_address_of_extra_arg_5() { return &___extra_arg_5; }
	inline void set_extra_arg_5(intptr_t value)
	{
		___extra_arg_5 = value;
	}

	inline static int32_t get_offset_of_method_code_6() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_code_6)); }
	inline intptr_t get_method_code_6() const { return ___method_code_6; }
	inline intptr_t* get_address_of_method_code_6() { return &___method_code_6; }
	inline void set_method_code_6(intptr_t value)
	{
		___method_code_6 = value;
	}

	inline static int32_t get_offset_of_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_info_7)); }
	inline MethodInfo_t * get_method_info_7() const { return ___method_info_7; }
	inline MethodInfo_t ** get_address_of_method_info_7() { return &___method_info_7; }
	inline void set_method_info_7(MethodInfo_t * value)
	{
		___method_info_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___method_info_7), (void*)value);
	}

	inline static int32_t get_offset_of_original_method_info_8() { return static_cast<int32_t>(offsetof(Delegate_t, ___original_method_info_8)); }
	inline MethodInfo_t * get_original_method_info_8() const { return ___original_method_info_8; }
	inline MethodInfo_t ** get_address_of_original_method_info_8() { return &___original_method_info_8; }
	inline void set_original_method_info_8(MethodInfo_t * value)
	{
		___original_method_info_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___original_method_info_8), (void*)value);
	}

	inline static int32_t get_offset_of_data_9() { return static_cast<int32_t>(offsetof(Delegate_t, ___data_9)); }
	inline DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * get_data_9() const { return ___data_9; }
	inline DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 ** get_address_of_data_9() { return &___data_9; }
	inline void set_data_9(DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * value)
	{
		___data_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___data_9), (void*)value);
	}

	inline static int32_t get_offset_of_method_is_virtual_10() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_is_virtual_10)); }
	inline bool get_method_is_virtual_10() const { return ___method_is_virtual_10; }
	inline bool* get_address_of_method_is_virtual_10() { return &___method_is_virtual_10; }
	inline void set_method_is_virtual_10(bool value)
	{
		___method_is_virtual_10 = value;
	}
};

// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	int32_t ___method_is_virtual_10;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	int32_t ___method_is_virtual_10;
};

// agora_gaming_rtc.VIDEO_FRAME_TYPE
struct VIDEO_FRAME_TYPE_tFA636AE8F0558764641AFC02F7EE081AE7BD98D2 
{
public:
	// System.Int32 agora_gaming_rtc.VIDEO_FRAME_TYPE::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(VIDEO_FRAME_TYPE_tFA636AE8F0558764641AFC02F7EE081AE7BD98D2, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
public:
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* ___delegates_11;

public:
	inline static int32_t get_offset_of_delegates_11() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___delegates_11)); }
	inline DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* get_delegates_11() const { return ___delegates_11; }
	inline DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8** get_address_of_delegates_11() { return &___delegates_11; }
	inline void set_delegates_11(DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* value)
	{
		___delegates_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___delegates_11), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_11;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_11;
};

// agora_gaming_rtc.VideoFrame
struct VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E 
{
public:
	// agora_gaming_rtc.VIDEO_FRAME_TYPE agora_gaming_rtc.VideoFrame::type
	int32_t ___type_0;
	// System.Int32 agora_gaming_rtc.VideoFrame::width
	int32_t ___width_1;
	// System.Int32 agora_gaming_rtc.VideoFrame::height
	int32_t ___height_2;
	// System.Int32 agora_gaming_rtc.VideoFrame::yStride
	int32_t ___yStride_3;
	// System.Byte[] agora_gaming_rtc.VideoFrame::buffer
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___buffer_4;
	// System.Int32 agora_gaming_rtc.VideoFrame::rotation
	int32_t ___rotation_5;
	// System.Int64 agora_gaming_rtc.VideoFrame::renderTimeMs
	int64_t ___renderTimeMs_6;
	// System.Int32 agora_gaming_rtc.VideoFrame::avsync_type
	int32_t ___avsync_type_7;

public:
	inline static int32_t get_offset_of_type_0() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___type_0)); }
	inline int32_t get_type_0() const { return ___type_0; }
	inline int32_t* get_address_of_type_0() { return &___type_0; }
	inline void set_type_0(int32_t value)
	{
		___type_0 = value;
	}

	inline static int32_t get_offset_of_width_1() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___width_1)); }
	inline int32_t get_width_1() const { return ___width_1; }
	inline int32_t* get_address_of_width_1() { return &___width_1; }
	inline void set_width_1(int32_t value)
	{
		___width_1 = value;
	}

	inline static int32_t get_offset_of_height_2() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___height_2)); }
	inline int32_t get_height_2() const { return ___height_2; }
	inline int32_t* get_address_of_height_2() { return &___height_2; }
	inline void set_height_2(int32_t value)
	{
		___height_2 = value;
	}

	inline static int32_t get_offset_of_yStride_3() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___yStride_3)); }
	inline int32_t get_yStride_3() const { return ___yStride_3; }
	inline int32_t* get_address_of_yStride_3() { return &___yStride_3; }
	inline void set_yStride_3(int32_t value)
	{
		___yStride_3 = value;
	}

	inline static int32_t get_offset_of_buffer_4() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___buffer_4)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_buffer_4() const { return ___buffer_4; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_buffer_4() { return &___buffer_4; }
	inline void set_buffer_4(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___buffer_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___buffer_4), (void*)value);
	}

	inline static int32_t get_offset_of_rotation_5() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___rotation_5)); }
	inline int32_t get_rotation_5() const { return ___rotation_5; }
	inline int32_t* get_address_of_rotation_5() { return &___rotation_5; }
	inline void set_rotation_5(int32_t value)
	{
		___rotation_5 = value;
	}

	inline static int32_t get_offset_of_renderTimeMs_6() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___renderTimeMs_6)); }
	inline int64_t get_renderTimeMs_6() const { return ___renderTimeMs_6; }
	inline int64_t* get_address_of_renderTimeMs_6() { return &___renderTimeMs_6; }
	inline void set_renderTimeMs_6(int64_t value)
	{
		___renderTimeMs_6 = value;
	}

	inline static int32_t get_offset_of_avsync_type_7() { return static_cast<int32_t>(offsetof(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E, ___avsync_type_7)); }
	inline int32_t get_avsync_type_7() const { return ___avsync_type_7; }
	inline int32_t* get_address_of_avsync_type_7() { return &___avsync_type_7; }
	inline void set_avsync_type_7(int32_t value)
	{
		___avsync_type_7 = value;
	}
};

// Native definition for P/Invoke marshalling of agora_gaming_rtc.VideoFrame
struct VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke
{
	int32_t ___type_0;
	int32_t ___width_1;
	int32_t ___height_2;
	int32_t ___yStride_3;
	Il2CppSafeArray/*NONE*/* ___buffer_4;
	int32_t ___rotation_5;
	int64_t ___renderTimeMs_6;
	int32_t ___avsync_type_7;
};
// Native definition for COM marshalling of agora_gaming_rtc.VideoFrame
struct VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_com
{
	int32_t ___type_0;
	int32_t ___width_1;
	int32_t ___height_2;
	int32_t ___yStride_3;
	Il2CppSafeArray/*NONE*/* ___buffer_4;
	int32_t ___rotation_5;
	int64_t ___renderTimeMs_6;
	int32_t ___avsync_type_7;
};

// System.AsyncCallback
struct AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA  : public MulticastDelegate_t
{
public:

public:
};


// agora_gaming_rtc.VideoRawDataManager/OnCaptureVideoFrameHandler
struct OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510  : public MulticastDelegate_t
{
public:

public:
};


// agora_gaming_rtc.VideoRawDataManager/OnRenderVideoFrameHandler
struct OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Object[]
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) RuntimeObject * m_Items[1];

public:
	inline RuntimeObject * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Delegate[]
struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Delegate_t * m_Items[1];

public:
	inline Delegate_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};

IL2CPP_EXTERN_C void VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshal_pinvoke(const VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E& unmarshaled, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshal_pinvoke_back(const VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke& marshaled, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E& unmarshaled);
IL2CPP_EXTERN_C void VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshal_pinvoke_cleanup(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke& marshaled);


// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Boolean System.String::Equals(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_Equals_m8A062B96B61A7D652E7D73C9B3E904F6B0E5F41D (String_t* __this, String_t* ___value0, const RuntimeMethod* method);
// System.Void TestHelloUnityVideo/<>c::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_mBC6D7C44DE2E7011CCB39835F93B810778FCF08C (U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE * __this, const RuntimeMethod* method);
// System.String agora_gaming_rtc.IRtcEngine::GetErrorDescription(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* IRtcEngine_GetErrorDescription_m0B845817DE219231EDBA925C4FFC9EE4278EB3AE (int32_t ___code0, const RuntimeMethod* method);
// System.Void UnityEngine.Debug::LogWarningFormat(System.String,System.Object[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogWarningFormat_m405E9C0A631F815816F349D7591DD545932FF774 (String_t* ___format0, ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* ___args1, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void SoundManagement/<>c__DisplayClass2_0::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__DisplayClass2_0__ctor_m5500FABAA6DBFD5853B3DE308C8E16DDC9F01951 (U3CU3Ec__DisplayClass2_0_t6F378E20D5918FF686AF22D61F6E24B85BA63671 * __this, const RuntimeMethod* method)
{
	{
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Boolean SoundManagement/<>c__DisplayClass2_0::<PlaySound>b__0(Sound)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CU3Ec__DisplayClass2_0_U3CPlaySoundU3Eb__0_m6A58DA07493CA9495ADBEA7C953673EEC44B8578 (U3CU3Ec__DisplayClass2_0_t6F378E20D5918FF686AF22D61F6E24B85BA63671 * __this, Sound_tF983595F9C621A86B56E05F9778810369E90A0FE * ___sound0, const RuntimeMethod* method)
{
	{
		// Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
		Sound_tF983595F9C621A86B56E05F9778810369E90A0FE * L_0 = ___sound0;
		NullCheck(L_0);
		String_t* L_1 = L_0->get_name_1();
		String_t* L_2 = __this->get_name_0();
		NullCheck(L_1);
		bool L_3;
		L_3 = String_Equals_m8A062B96B61A7D652E7D73C9B3E904F6B0E5F41D(L_1, L_2, /*hidden argument*/NULL);
		return L_3;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void TestHelloUnityVideo/<>c::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__cctor_m32E2558DF653540DD62C0690CDF18FCE6CC41A65 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE * L_0 = (U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE *)il2cpp_codegen_object_new(U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_il2cpp_TypeInfo_var);
		U3CU3Ec__ctor_mBC6D7C44DE2E7011CCB39835F93B810778FCF08C(L_0, /*hidden argument*/NULL);
		((U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE_il2cpp_TypeInfo_var))->set_U3CU3E9_0(L_0);
		return;
	}
}
// System.Void TestHelloUnityVideo/<>c::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_mBC6D7C44DE2E7011CCB39835F93B810778FCF08C (U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE * __this, const RuntimeMethod* method)
{
	{
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void TestHelloUnityVideo/<>c::<join>b__3_0(System.Int32,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec_U3CjoinU3Eb__3_0_m28F85F55320126411E83B7AA81FE0E6D802CC710 (U3CU3Ec_t6BFF41E5DB4C2E2FCC3052DFFB60DAE1A40136CE * __this, int32_t ___warn0, String_t* ___msg1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IRtcEngine_tAAB918008B7BD39030805371269AB0D499C5F647_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5B2855F5FF0FDAD6557B888B208FF0AE17AA3ED2);
		s_Il2CppMethodInitialized = true;
	}
	{
		// Debug.LogWarningFormat("Warning code:{0} msg:{1}", warn, IRtcEngine.GetErrorDescription(warn));
		ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* L_0 = (ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE*)(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE*)SZArrayNew(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE_il2cpp_TypeInfo_var, (uint32_t)2);
		ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* L_1 = L_0;
		int32_t L_2 = ___warn0;
		int32_t L_3 = L_2;
		RuntimeObject * L_4 = Box(Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_il2cpp_TypeInfo_var, &L_3);
		NullCheck(L_1);
		ArrayElementTypeCheck (L_1, L_4);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject *)L_4);
		ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* L_5 = L_1;
		int32_t L_6 = ___warn0;
		IL2CPP_RUNTIME_CLASS_INIT(IRtcEngine_tAAB918008B7BD39030805371269AB0D499C5F647_il2cpp_TypeInfo_var);
		String_t* L_7;
		L_7 = IRtcEngine_GetErrorDescription_m0B845817DE219231EDBA925C4FFC9EE4278EB3AE(L_6, /*hidden argument*/NULL);
		NullCheck(L_5);
		ArrayElementTypeCheck (L_5, L_7);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(1), (RuntimeObject *)L_7);
		IL2CPP_RUNTIME_CLASS_INIT(Debug_tEB68BCBEB8EFD60F8043C67146DC05E7F50F374B_il2cpp_TypeInfo_var);
		Debug_LogWarningFormat_m405E9C0A631F815816F349D7591DD545932FF774(_stringLiteral5B2855F5FF0FDAD6557B888B208FF0AE17AA3ED2, L_5, /*hidden argument*/NULL);
		// };
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510 (OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510 * __this, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  ___videoFrame0, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_method_pointer(((RuntimeDelegate*)__this)->method));

	// Marshaling of parameter '___videoFrame0' to native representation
	VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke ____videoFrame0_marshaled = {};
	VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshal_pinvoke(___videoFrame0, ____videoFrame0_marshaled);

	// Native function invocation
	il2cppPInvokeFunc(____videoFrame0_marshaled);

	// Marshaling cleanup of parameter '___videoFrame0' native representation
	VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshal_pinvoke_cleanup(____videoFrame0_marshaled);

}
// System.Void agora_gaming_rtc.VideoRawDataManager/OnCaptureVideoFrameHandler::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OnCaptureVideoFrameHandler__ctor_m9FF73F27AAE42C238B7A93D3DB18B7AEC06CE97E (OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void agora_gaming_rtc.VideoRawDataManager/OnCaptureVideoFrameHandler::Invoke(agora_gaming_rtc.VideoFrame)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OnCaptureVideoFrameHandler_Invoke_mD9D231CA743E7D19DFCED5DCEB5E640A8E1CA627 (OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510 * __this, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  ___videoFrame0, const RuntimeMethod* method)
{
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* delegateArrayToInvoke = __this->get_delegates_11();
	Delegate_t** delegatesToInvoke;
	il2cpp_array_size_t length;
	if (delegateArrayToInvoke != NULL)
	{
		length = delegateArrayToInvoke->max_length;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(delegateArrayToInvoke->GetAddressAtUnchecked(0));
	}
	else
	{
		length = 1;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(&__this);
	}

	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t* currentDelegate = delegatesToInvoke[i];
		Il2CppMethodPointer targetMethodPointer = currentDelegate->get_method_ptr_0();
		RuntimeObject* targetThis = currentDelegate->get_m_target_2();
		RuntimeMethod* targetMethod = (RuntimeMethod*)(currentDelegate->get_method_3());
		if (!il2cpp_codegen_method_is_virtual(targetMethod))
		{
			il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
		}
		bool ___methodIsStatic = MethodIsStatic(targetMethod);
		int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
		if (___methodIsStatic)
		{
			if (___parameterCount == 1)
			{
				// open
				typedef void (*FunctionPointerType) (VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___videoFrame0, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___videoFrame0, targetMethod);
			}
		}
		else
		{
			// closed
			if (targetThis != NULL && il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_generic_instance(targetMethod))
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						GenericInterfaceActionInvoker1< VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(targetMethod, targetThis, ___videoFrame0);
					else
						GenericVirtActionInvoker1< VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(targetMethod, targetThis, ___videoFrame0);
				}
				else
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						InterfaceActionInvoker1< VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___videoFrame0);
					else
						VirtActionInvoker1< VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___videoFrame0);
				}
			}
			else
			{
				if (targetThis == NULL)
				{
					typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)((RuntimeObject*)(reinterpret_cast<RuntimeObject*>(&___videoFrame0) - 1), targetMethod);
				}
				else
				{
					typedef void (*FunctionPointerType) (void*, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E , const RuntimeMethod*);
					((FunctionPointerType)targetMethodPointer)(targetThis, ___videoFrame0, targetMethod);
				}
			}
		}
	}
}
// System.IAsyncResult agora_gaming_rtc.VideoRawDataManager/OnCaptureVideoFrameHandler::BeginInvoke(agora_gaming_rtc.VideoFrame,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* OnCaptureVideoFrameHandler_BeginInvoke_mEC032259190BD6490721C74E4790B44D32D1B67C (OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510 * __this, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  ___videoFrame0, AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___callback1, RuntimeObject * ___object2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[2] = {0};
	__d_args[0] = Box(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_il2cpp_TypeInfo_var, &___videoFrame0);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback1, (RuntimeObject*)___object2);;
}
// System.Void agora_gaming_rtc.VideoRawDataManager/OnCaptureVideoFrameHandler::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OnCaptureVideoFrameHandler_EndInvoke_m5EC900DC7E7F6B86A07B804EA84CA7632AD629B6 (OnCaptureVideoFrameHandler_t18A0C3910C466DE326CB7D17E6C13D98914AD510 * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7 (OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7 * __this, uint32_t ___uid0, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  ___videoFrame1, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_method_pointer(((RuntimeDelegate*)__this)->method));

	// Marshaling of parameter '___videoFrame1' to native representation
	VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshaled_pinvoke ____videoFrame1_marshaled = {};
	VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshal_pinvoke(___videoFrame1, ____videoFrame1_marshaled);

	// Native function invocation
	il2cppPInvokeFunc(___uid0, ____videoFrame1_marshaled);

	// Marshaling cleanup of parameter '___videoFrame1' native representation
	VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_marshal_pinvoke_cleanup(____videoFrame1_marshaled);

}
// System.Void agora_gaming_rtc.VideoRawDataManager/OnRenderVideoFrameHandler::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OnRenderVideoFrameHandler__ctor_m68A7BA9276DC486355FD374AAD8855510C3F36FB (OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	__this->set_method_ptr_0(il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1));
	__this->set_method_3(___method1);
	__this->set_m_target_2(___object0);
}
// System.Void agora_gaming_rtc.VideoRawDataManager/OnRenderVideoFrameHandler::Invoke(System.UInt32,agora_gaming_rtc.VideoFrame)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OnRenderVideoFrameHandler_Invoke_m830C98BA5017F4448C6C124ED31458BE7A5D951A (OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7 * __this, uint32_t ___uid0, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  ___videoFrame1, const RuntimeMethod* method)
{
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* delegateArrayToInvoke = __this->get_delegates_11();
	Delegate_t** delegatesToInvoke;
	il2cpp_array_size_t length;
	if (delegateArrayToInvoke != NULL)
	{
		length = delegateArrayToInvoke->max_length;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(delegateArrayToInvoke->GetAddressAtUnchecked(0));
	}
	else
	{
		length = 1;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(&__this);
	}

	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t* currentDelegate = delegatesToInvoke[i];
		Il2CppMethodPointer targetMethodPointer = currentDelegate->get_method_ptr_0();
		RuntimeObject* targetThis = currentDelegate->get_m_target_2();
		RuntimeMethod* targetMethod = (RuntimeMethod*)(currentDelegate->get_method_3());
		if (!il2cpp_codegen_method_is_virtual(targetMethod))
		{
			il2cpp_codegen_raise_execution_engine_exception_if_method_is_not_found(targetMethod);
		}
		bool ___methodIsStatic = MethodIsStatic(targetMethod);
		int ___parameterCount = il2cpp_codegen_method_parameter_count(targetMethod);
		if (___methodIsStatic)
		{
			if (___parameterCount == 2)
			{
				// open
				typedef void (*FunctionPointerType) (uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(___uid0, ___videoFrame1, targetMethod);
			}
			else
			{
				// closed
				typedef void (*FunctionPointerType) (void*, uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___uid0, ___videoFrame1, targetMethod);
			}
		}
		else
		{
			// closed
			if (targetThis != NULL && il2cpp_codegen_method_is_virtual(targetMethod) && !il2cpp_codegen_object_is_of_sealed_type(targetThis) && il2cpp_codegen_delegate_has_invoker((Il2CppDelegate*)__this))
			{
				if (il2cpp_codegen_method_is_generic_instance(targetMethod))
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						GenericInterfaceActionInvoker2< uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(targetMethod, targetThis, ___uid0, ___videoFrame1);
					else
						GenericVirtActionInvoker2< uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(targetMethod, targetThis, ___uid0, ___videoFrame1);
				}
				else
				{
					if (il2cpp_codegen_method_is_interface_method(targetMethod))
						InterfaceActionInvoker2< uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), il2cpp_codegen_method_get_declaring_type(targetMethod), targetThis, ___uid0, ___videoFrame1);
					else
						VirtActionInvoker2< uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  >::Invoke(il2cpp_codegen_method_get_slot(targetMethod), targetThis, ___uid0, ___videoFrame1);
				}
			}
			else
			{
				typedef void (*FunctionPointerType) (void*, uint32_t, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E , const RuntimeMethod*);
				((FunctionPointerType)targetMethodPointer)(targetThis, ___uid0, ___videoFrame1, targetMethod);
			}
		}
	}
}
// System.IAsyncResult agora_gaming_rtc.VideoRawDataManager/OnRenderVideoFrameHandler::BeginInvoke(System.UInt32,agora_gaming_rtc.VideoFrame,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* OnRenderVideoFrameHandler_BeginInvoke_mC581F8C23DF3735154AF4D4D81BFD38F4C031E81 (OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7 * __this, uint32_t ___uid0, VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E  ___videoFrame1, AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___callback2, RuntimeObject * ___object3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_tE60352A06233E4E69DD198BCC67142159F686B15_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[3] = {0};
	__d_args[0] = Box(UInt32_tE60352A06233E4E69DD198BCC67142159F686B15_il2cpp_TypeInfo_var, &___uid0);
	__d_args[1] = Box(VideoFrame_tC33A26E5DA4ED44EE1D469D54FEA56C62AA39A2E_il2cpp_TypeInfo_var, &___videoFrame1);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback2, (RuntimeObject*)___object3);;
}
// System.Void agora_gaming_rtc.VideoRawDataManager/OnRenderVideoFrameHandler::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OnRenderVideoFrameHandler_EndInvoke_mAF19AEDC940E468CDC5D3EA0ABA7A3A4DCD51E46 (OnRenderVideoFrameHandler_tFF73ED0FBB68BFF4D05F751C8B6F1FC8443BCDE7 * __this, RuntimeObject* ___result0, const RuntimeMethod* method)
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
