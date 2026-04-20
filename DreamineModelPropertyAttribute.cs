using System;

namespace Dreamine.MVVM.Attributes
{
    /// <summary>
    /// ViewModel 필드를 Model 프로퍼티에 위임되는 프로퍼티로 생성하도록 지정하는 특성입니다.
    /// </summary>
    /// <remarks>
    /// 이 특성이 필드에 적용되면 소스 생성기는 해당 필드를 기반으로
    /// Model의 멤버에 접근하는 프로퍼티를 생성할 수 있습니다.
    /// <para>
    /// <see cref="ModelPropertyName"/>을 지정하지 않으면 필드명을 기준으로
    /// 기본 명명 규칙이 적용됩니다.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class DreamineModelPropertyAttribute : Attribute
    {
        /// <summary>
        /// 연결할 Model 프로퍼티 이름을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 값을 지정하지 않으면 필드명을 기반으로 자동 결정됩니다.
        /// </remarks>
        public string? ModelPropertyName { get; }

        /// <summary>
        /// Model 프로퍼티 이름을 명시하지 않고
        /// <see cref="DreamineModelPropertyAttribute"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public DreamineModelPropertyAttribute()
        {
        }

        /// <summary>
        /// 지정한 Model 프로퍼티 이름으로
        /// <see cref="DreamineModelPropertyAttribute"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="modelPropertyName">연결할 Model 프로퍼티 이름입니다.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="modelPropertyName"/>가 null인 경우 발생합니다.
        /// </exception>
        public DreamineModelPropertyAttribute(string modelPropertyName)
        {
            ModelPropertyName = modelPropertyName ?? throw new ArgumentNullException(nameof(modelPropertyName));
        }
    }
}