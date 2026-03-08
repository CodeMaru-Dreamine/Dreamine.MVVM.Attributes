using System;

namespace Dreamine.MVVM.Attributes
{
	/// <summary>
	/// ViewModel 필드를 Model 프로퍼티에 프록시(Proxy)로 바인딩하도록 지정합니다.
	/// - 예: [DreamineModelProperty] private string _readme;
	///   -> public string Readme { get => Model.Readme; set => Model.Readme = value; ... }
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public sealed class DreamineModelPropertyAttribute : Attribute
	{
		/// <summary>
		/// Model 프로퍼티 이름을 명시합니다. (기본: 필드명에서 PascalCase 변환)
		/// </summary>
		public string? ModelPropertyName { get; }

		/// <summary>
		/// 생성자
		/// </summary>
		public DreamineModelPropertyAttribute()
		{
		}

		/// <summary>
		/// 생성자
		/// </summary>
		/// <param name="modelPropertyName">Model 프로퍼티명</param>
		public DreamineModelPropertyAttribute(string modelPropertyName)
		{
			ModelPropertyName = modelPropertyName;
		}
	}
}
