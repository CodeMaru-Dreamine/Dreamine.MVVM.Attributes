using System;

namespace Dreamine.MVVM.Attributes
{
    /// <summary>
    /// 대상 메서드를 호출하는 커맨드 생성을 지정하는 특성입니다.
    /// </summary>
    /// <remarks>
    /// 지정된 <see cref="TargetMethod"/>를 호출하는 커맨드를 생성하며,
    /// 필요 시 반환값을 <see cref="BindTo"/>에 지정한 프로퍼티에 자동 대입합니다.
    /// <para>예: <c>Event.ReadmeClick</c>, <c>Service.Load</c>, <c>Foo</c></para>
    /// <para>
    /// 이 특성은 소스 생성기와 함께 사용되며, 대상 메서드를 선언한 ViewModel 메서드는
    /// partial 메서드로 유지하는 것을 권장합니다.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class DreamineCommandAttribute : Attribute
    {
        /// <summary>
        /// 호출할 대상 메서드 경로를 가져옵니다.
        /// </summary>
        public string TargetMethod { get; }

        /// <summary>
        /// 대상 메서드의 반환값을 자동 대입할 프로퍼티 이름을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 이 값이 지정되면 생성된 커맨드는 대상 메서드의 반환값을 해당 프로퍼티에 대입합니다.
        /// </remarks>
        public string? BindTo { get; set; }

        /// <summary>
        /// 생성될 커맨드 프로퍼티 이름을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 지정하지 않으면 기본적으로 "{메서드명}Command" 형식이 사용됩니다.
        /// </remarks>
        public string? CommandName { get; set; }

        /// <summary>
        /// <see cref="DreamineCommandAttribute"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="targetMethod">호출할 대상 메서드 경로입니다.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="targetMethod"/>가 null인 경우 발생합니다.
        /// </exception>
        public DreamineCommandAttribute(string targetMethod)
        {
            TargetMethod = targetMethod ?? throw new ArgumentNullException(nameof(targetMethod));
        }
    }
}