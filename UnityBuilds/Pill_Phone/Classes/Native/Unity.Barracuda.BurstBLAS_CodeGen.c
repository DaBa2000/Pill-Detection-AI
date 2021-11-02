#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Boolean Unity.Barracuda.BurstBLAS::IsNative()
extern void BurstBLAS_IsNative_m77585B97BB890CB54DB68EB2F18F06F777546B1B (void);
// 0x00000002 System.Boolean Unity.Barracuda.BurstBLAS::IsCurrentPlatformSupported()
extern void BurstBLAS_IsCurrentPlatformSupported_m3ED8F95B69E7C69EB66807DA08612A0F51463682 (void);
// 0x00000003 System.Void Unity.Barracuda.BurstBLAS::SGEMM(System.Single*,System.Int32,System.Int32,System.Single*,System.Int32,System.Int32,System.Single*,System.Int32,System.Int32,System.Int32,System.Boolean,System.Boolean)
extern void BurstBLAS_SGEMM_mA5159A52C4AA70D7D9CACDBCC940318C04031745 (void);
// 0x00000004 Unity.Jobs.JobHandle Unity.Barracuda.BurstBLAS::ScheduleSGEMM(Unity.Jobs.JobHandle,System.Single*,System.Int32,System.Int32,System.Single*,System.Int32,System.Int32,System.Single*,System.Int32,System.Int32,System.Int32,System.Boolean,System.Boolean)
extern void BurstBLAS_ScheduleSGEMM_m9B77247DAACA6D740DBAAE4C856C054CEEA4EC20 (void);
// 0x00000005 System.Void Unity.Barracuda.BurstBLAS::.ctor()
extern void BurstBLAS__ctor_m4C793DE6A3B23E1EBF7FF90D2D4F9E576946C3D5 (void);
static Il2CppMethodPointer s_methodPointers[5] = 
{
	BurstBLAS_IsNative_m77585B97BB890CB54DB68EB2F18F06F777546B1B,
	BurstBLAS_IsCurrentPlatformSupported_m3ED8F95B69E7C69EB66807DA08612A0F51463682,
	BurstBLAS_SGEMM_mA5159A52C4AA70D7D9CACDBCC940318C04031745,
	BurstBLAS_ScheduleSGEMM_m9B77247DAACA6D740DBAAE4C856C054CEEA4EC20,
	BurstBLAS__ctor_m4C793DE6A3B23E1EBF7FF90D2D4F9E576946C3D5,
};
static const int32_t s_InvokerIndices[5] = 
{
	3292,
	3292,
	20,
	17,
	3322,
};
extern const CustomAttributesCacheGenerator g_Unity_Barracuda_BurstBLAS_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_Unity_Barracuda_BurstBLAS_CodeGenModule;
const Il2CppCodeGenModule g_Unity_Barracuda_BurstBLAS_CodeGenModule = 
{
	"Unity.Barracuda.BurstBLAS.dll",
	5,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	g_Unity_Barracuda_BurstBLAS_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
