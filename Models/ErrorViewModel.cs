using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Convenience.Models
{
    /// <summary>
    /// �G���[�y�[�W�p�r���[���f��
    /// </summary>
    public class ErrorViewModel  {
        /// <summary>
        /// ���N�G�X�gID
        /// </summary>
        public string? RequestId { get; set; }
        /// <summary>
        /// ��L���N�G�X�gID���o�����o���Ȃ���
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        /// <summary>
        /// �X�e�[�^�X�R�[�h
        /// </summary>
        public int? StatusCode { get; set; }
        /// <summary>
        /// �G���[�C�x���g��������
        /// </summary>
        public DateTime? EventAt { get; set; }
        /// <summary>
        /// <para>�G���[�������̏ڍ׏��</para>
        /// <para>��O�����������p�X���O���̂Ȃǂ̏��</para>
        /// </summary>
        public IExceptionHandlerPathFeature? ExceptionHandlerPathFeature;

        /// <summary>
        /// <para>�G���[�n���h�����O�Ɋ֘A����@�\��񋟂���C���^�[�t�F�[�X</para>
        /// <para>���ɁA404 Not Found �� 500 Internal Server Error �Ȃǂ̃X�e�[�^�X�R�[�h�����������ꍇ�ɁA</para>
        /// <para>�Ď��s����郊�N�G�X�g�̏����擾���邽�߂Ɏg�p</para>
        /// </summary>
        public IStatusCodeReExecuteFeature? StatusCodeReExecuteFeature;

    }
}
