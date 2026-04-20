using System;

namespace Dreamine.MVVM.Attributes
{
    /// <summary>
    /// 모델 연결 대상을 표시하는 특성입니다.
    /// </summary>
    /// <remarks>
    /// 이 특성은 클래스 또는 필드에 적용되며,
    /// 소스 생성기 또는 프레임워크 로직에서 모델 관련 멤버를 식별하는 데 사용됩니다.
    /// <para>
    /// <see cref="PropertyName"/>이 지정되면 생성될 프로퍼티 이름으로 사용되고,
    /// 지정하지 않으면 기본 명명 규칙이 적용됩니다.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class DreamineModelAttribute : Attribute
    {
        /// <summary>
        /// 생성될 프로퍼티 이름을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 값을 지정하지 않으면 필드명 또는 대상 이름을 기준으로 자동 생성됩니다.
        /// </remarks>
        public string? PropertyName { get; }

        /// <summary>
        /// <see cref="DreamineModelAttribute"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="propertyName">
        /// 명시적으로 지정할 프로퍼티 이름입니다. 지정하지 않으면 기본 명명 규칙이 적용됩니다.
        /// </param>
        public DreamineModelAttribute(string? propertyName = null)
        {
            PropertyName = propertyName;
        }
    }
}