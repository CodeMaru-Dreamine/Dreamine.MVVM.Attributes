using System;

namespace Dreamine.MVVM.Attributes
{
    /// <summary>
    /// \brief Event/Service 등의 대상 메서드를 호출하고, 반환값을 특정 프로퍼티에 자동 대입하는 커맨드 생성 Attribute.
    /// \details
    /// - TargetMethod: 호출할 대상 메서드 경로(예: "Event.ReadmeClick")
    /// - BindTo: 반환값을 대입할 프로퍼티 이름(예: "Readme"). 생략 가능.
    /// \note
    /// - ViewModel 메서드는 partial 이어야 하며, 바디를 비워두는 것을 권장합니다.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class DreamineCommandAttribute : Attribute
    {
        /// <summary>
        /// \brief 호출할 대상 메서드 경로.
        /// \details 예: "Event.ReadmeClick", "Service.Load", "Foo"
        /// </summary>
        public string TargetMethod { get; }

        /// <summary>
        /// \brief 반환값을 자동 대입할 프로퍼티 이름.
        /// \details 지정 시: var result = TargetMethod(); BindTo = result;
        /// </summary>
        public string? BindTo { get; set; }

        /// <summary>
        /// \brief 커맨드 프로퍼티 이름을 강제 지정합니다.
        /// \details 기본값은 "{MethodName}Command"
        /// </summary>
        public string? CommandName { get; set; }

        /// <summary>
        /// \brief DreamineCommandAttribute 생성자.
        /// </summary>
        /// <param name="targetMethod">\brief 호출할 대상 메서드 경로</param>
        public DreamineCommandAttribute(string targetMethod)
        {
            TargetMethod = targetMethod;
        }
    }
}