using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

// ver 1.0.1, 2023.12.11 : 한글 출력 가능, 선택 창 출력 가능
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

    // IntPtr hwnd : 소유자 윈도우에 대한 핸들
    // String lpText : 표시할 메시지
    // String lpCaption : 윈도우 상자의 제목
    // uint uType : 윈도우의 타입
    static extern int MessageBox(IntPtr hwnd, String lpText, String lpCaption, uint uType);

    /// <summary>
    /// Shows Error alert box with OK button.
    /// </summary>
    /// <param name="text">Main alert text / content.</param>
    /// <param name="caption">Message box title.</param>
    /// // text가 내용, caption이 창이름입니다.
    public static void Error(string text, string caption)
    {
        // 에러 메시지 창을 띄웁니다.
        try
        {
            MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000010L));
        }
        catch (Exception ex) { }
    }
    // text가 내용, caption이 창이름입니다.
    public static void Mark(string text, string caption)
    {
        // 경고 메시지 창을 띄웁니다.
        try
        {
            MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000040L));
        }
        catch (Exception ex) { }
    }
    // text가 내용, caption이 창 이름입니다.
    public static bool ShowYesNo(string text, string caption)
    {
        // "예", "아니오" 선택 창을 띄웁니다.
        try
        {
            int result = MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000001L | 0x00000020L));

            // 결과를 확인하여 "예"를 선택했으면 true 반환, 그 외는 false 반환
            return result == 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}