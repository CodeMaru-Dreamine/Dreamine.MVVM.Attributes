using System;

namespace Dreamine.MVVM.Attributes
{
    /// <summary>
    /// 필드를 속성 생성 대상으로 표시하는 특성입니다.
    /// </summary>
    /// <remarks>
    /// 이 특성이 적용된 필드는 소스 생성기에 의해
    /// <c>INotifyPropertyChanged</c> 패턴을 따르는 프로퍼티 생성 대상으로 처리될 수 있습니다.
    /// <para>
    /// <see cref="PropertyName"/>을 지정하지 않으면 필드명을 기준으로
    /// 기본 명명 규칙이 적용됩니다.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class DreaminePropertyAttribute : Attribute
    {
        /// <summary>
        /// 생성될 프로퍼티 이름을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 값을 지정하지 않으면 필드명을 기준으로 자동 생성됩니다.
        /// </remarks>
        public string? PropertyName { get; }

        /// <summary>
        /// <see cref="DreaminePropertyAttribute"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="propertyName">
        /// 명시적으로 지정할 프로퍼티 이름입니다. 지정하지 않으면 기본 명명 규칙이 적용됩니다.
        /// </param>
        public DreaminePropertyAttribute(string? propertyName = null)
        {
            PropertyName = propertyName;
        }
    }
}