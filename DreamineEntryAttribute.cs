using System;

namespace Dreamine.MVVM.Attributes
{
    /// <summary>
    /// Dreamine 애플리케이션의 진입 클래스를 표시하는 특성입니다.
    /// </summary>
    /// <remarks>
    /// 이 특성은 소스 생성기 또는 프레임워크 초기화 로직에서
    /// 애플리케이션 시작 지점을 식별하기 위한 표식으로 사용됩니다.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class DreamineEntryAttribute : Attribute
    {
    }
}