using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

// ver 1.0.1, 2023.12.11 : �ѱ� ��� ����, ���� â ��� ����
/// <see>https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox</see>
public static class NativeWinAlert
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();

    public static System.IntPtr GetWindowHandle()
    {
        return GetActiveWindow();
    }

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

    // IntPtr hwnd : ������ �����쿡 ���� �ڵ�
    // String lpText : ǥ���� �޽���
    // String lpCaption : ������ ������ ����
    // uint uType : �������� Ÿ��
    static extern int MessageBox(IntPtr hwnd, String lpText, String lpCaption, uint uType);

    /// <summary>
    /// Shows Error alert box with OK button.
    /// </summary>
    /// <param name="text">Main alert text / content.</param>
    /// <param name="caption">Message box title.</param>
    /// // text�� ����, caption�� â�̸��Դϴ�.
    public static void Error(string text, string caption)
    {
        // ���� �޽��� â�� ���ϴ�.
        try
        {
            MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000010L));
        }
        catch (Exception ex) { }
    }
    // text�� ����, caption�� â�̸��Դϴ�.
    public static void Mark(string text, string caption)
    {
        // ��� �޽��� â�� ���ϴ�.
        try
        {
            MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000040L));
        }
        catch (Exception ex) { }
    }
    // text�� ����, caption�� â �̸��Դϴ�.
    public static bool ShowYesNo(string text, string caption)
    {
        // "��", "�ƴϿ�" ���� â�� ���ϴ�.
        try
        {
            int result = MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000001L | 0x00000020L));

            // ����� Ȯ���Ͽ� "��"�� ���������� true ��ȯ, �� �ܴ� false ��ȯ
            return result == 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}