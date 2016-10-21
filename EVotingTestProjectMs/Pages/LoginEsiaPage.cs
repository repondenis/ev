using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVotingTestProjectMs.Pages
{
    class LoginEsiaPage
    {
private static 

    }
}



надпись
<div class="slogan"> Доступ к сервисам электронного правительства</div>

тел/почта
<dl class="flt-lbl-box mobile-or-email" data-bind="visible: mobileOrEmail.visible">
<dt> Мобильный телефон или почта</dt>
<dd>
<input id = "mobileOrEmail" class="ui-inputfield flt-lbl-inp flt_lbl_inp" data-bind="value: mobileOrEmail.val" type="text">
<div class="field-error" data-bind="visible: mobileOrEmail.msgVisible" style="display: none;">
</dd>
</dl>

пароль
<dl class="flt-lbl-box password">
<dt> Пароль</dt>
<dd>
<input id = "password" class="ui-inputfield flt-lbl-inp flt_lbl_inp" name="password" data-bind="value: pwd.val" type="password">
<input id = "login" name="login" type="hidden">
<input id = "pwd_command" name="command" type="hidden">
<input id = "idType" name="idType" type="hidden">
<div class="field-error" data-bind="visible: pwd.msgVisible" style="display: none;">
</dd>
</dl>

ВОЙТИ
<div class="line-btns">
<button class="ui-button ui-widget button-big" type="button" data-bind="click: loginByPwd">
<span class="ui-button-text"> Войти</span>
</button>
</div>

Вход с помощью: СНИЛС Электронных средств
<a class="enter-item" href="javascript: void(0);" data-bind="visible: snils.canSwitchTo, click: toSnils" style=""> СНИЛС</a>
<a class="enter-item" href="javascript: void(0);" data-bind="visible: mobileOrEmail.canSwitchTo, click: toMobileOrEmail" style=""> Телефона/почты</a>
<a class="enter-item" href="javascript: void(0);" data-bind="visible: mobileOrEmail.canSwitchTo, click: toMobileOrEmail" style="display: none;"> Телефона/почты</a>
<a class="enter-item" href="javascript: void(0);" data-bind="click: switchDs"> Электронных средств</a>