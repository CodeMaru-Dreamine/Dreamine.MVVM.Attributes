using System;

namespace Dreamine.MVVM.Attributes
{
    /// <summary>
    /// 메서드를 커맨드 생성 대상으로 표시하는 특성입니다.
    /// </summary>
    /// <remarks>
    /// 이 특성이 적용된 메서드는 소스 생성기에 의해
    /// <c>ICommand</c> 구현 프로퍼티 생성 대상으로 처리될 수 있습니다.
    /// <para>
    /// <see cref="CommandName"/>을 지정하지 않으면 기본적으로
    /// "{메서드명}Command" 형식의 이름이 사용됩니다.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class RelayCommandAttribute : Attribute
    {
        /// <summary>
        /// 생성될 커맨드 프로퍼티 이름을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 값을 지정하지 않으면 메서드명을 기준으로 자동 생성됩니다.
        /// </remarks>
        public string? CommandName { get; }

        /// <summary>
        /// <see cref="RelayCommandAttribute"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="commandName">
        /// 명시적으로 지정할 커맨드 프로퍼티 이름입니다. 지정하지 않으면 기본 명명 규칙이 적용됩니다.
        /// </param>
        public RelayCommandAttribute(string? commandName = null)
        {
            CommandName = commandName;
        }
    }
}