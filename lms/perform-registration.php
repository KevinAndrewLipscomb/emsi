<?php
//
// $Id$
//
// Turn on all error reporting.
//
error_reporting(E_ALL);
//
// Determine, based on the name by which this file was invoked, whether or not to operate in production or test mode.
//
$foundation_dir = "../../../foundation";
require_once("$foundation_dir/f_runmode.phtml");
$mode = RunMode($PHP_SELF);
//
require_once("$foundation_dir/f_bodyopen.phtml");
require_once("$foundation_dir/f_connectselectdb.phtml");
require_once("$foundation_dir/f_password.phtml");
require_once("$foundation_dir/f_bevalidemailaddress.phtml");
require_once("f_foundvalid.phtml");
//
// Initialize optional parameters.
//
$_assert_email_address = '';
//
// Accept user-supplied parameters and copy them into local variables.
//
import_request_variables('PG','_');
$first_name = $_first_name;
$last_name = $_last_name;
$email_address = $_email_address;
$cert_num = $_cert_num;
$assert_email_address = $_assert_email_address;
//
?>
<html>

<head>
   <title>EMSI - Learning Management System Registration</title>
</head>

<? BodyOpen(); ?>
<table border="0" cellpadding="0" cellspacing="0" width="80%" align="center">
   <tr>
      <td>
         <table>
            <tr>
               <td><img align="center" valign="middle" src="http://www.emsi04.org/graphics/logo.gif"></td>
               <td>
                  <h6>EMSI LAMPapp host at Oscarsystem.com</h6>
                  <h1>Learning Management System Registration</h1>
               </td>
            </tr>
         </table>
         <hr>
         <br>
         <?php
         if (ConnectSelectDb("localhost","kalipso",Password(),"emsi") != "TRUE")
            {
            ?>
            <h2><i>Sorry...</i></h2>
            <b>
            <blockquote>
               <? echo "<p>The database is temporarily offline.&nbsp; Please try again later.</p>"; ?>
            </blockquote>            
            </b>
            <?php
            }
         else
            {
            //
            // Database is up.  Validate parameters.
            //
            if (
                  ($first_name != "")
               and
                  ($last_name != "")
               and
                  ($email_address != "")
               and
                  ($cert_num != "")
               )
            // then
               {
               if ($assert_email_address or BeValidEmailAddress($email_address,$mode))
                  {
                  $found_valid_rec = FoundValid($cert_num,$first_name,$last_name,$mode);
                  if ($found_valid_rec["value"])
                     {
                     mysql_query
                        (
                        "insert into " . $mode . "lms_applicant "
                        .  "set cert_num='$cert_num' "
                        .  ", cert_level_code='" . $found_valid_rec["cert_level_code"] . "' "
                        .  ", email_address='$email_address' "
                        .  ", application_timestamp='" . time() . "' "
                        )
                        or die("Insert failed with error: " . mysql_error());
                     echo "<b>Thanks!</b></p>\n";
                     echo "<p>Your application has been registered in EMSI's database.  You should receive your account "
                        . "information within ten days.</p>\n";
                     echo "<ul>\n"
                        . "   <li><p><a href=http://www.emsi04.org/services/prehosp-pers/lms/>Return to EMSI's LMS page</a></p></li>\n"
                        . "   <li><p><a href=http://www.emsi04.org/>Return to EMSI's home page</a></p></li>\n"
                        . "</ul>\n"
                        . "<p>Problems?&nbsp; Contact <a href=mailto:asst-director@emsi04.org><i>asst-director@emsi04.org</i></a>.</p>\n";
                     }
                  else
                     {
                     //
                     // Fill the page out with an error message and instructions.
                     //
                     ?>
                     <h2><i>Error!</i></h2>
                     <b>
                     <blockquote>
                        <p>That name and certification number do not match any record in our table of
                           LMS-eligible practitioners.</p>
                        <p>You can either:</p>
                        <ul>
                           <li><p>Press your browser's [<--&nbsp;BACK] button to correct the problem.</p></li>
                           <li>
                              <p>Call your regional EMS council to see why you aren't showing up as eligible.</p>
                              <p><small>To see which counties EMSI serves, see <a href=http://www.emsi04.org>EMSI's home
                                 page.</a></small></p>
                           </li>
                        </ul>
                     </blockquote>            
                     </b>
                     <?php
                     }
                  }
               else
                  {
                  //
                  // Fill the page out with a warning, instructions, and an opportunity to force acceptance of prior input.
                  //
                  echo "<h2><i>Warning!</i></h2>\n"
                     . "<b>\n"
                     . "<blockquote>\n"
                     . "<p><u>$email_address</u> doesn't seem to be a valid email address.&nbsp; Please check the spelling carefully.</p>\n"
                     . "<p>You can either:</p>\n"
                     . "<ul>\n"
                     . "   <li><p>Press your browser's [<--&nbsp;BACK] button to correct your entry, or...</p></li>\n"
                     . "      <form method=post action=http://oscarsystem.com/emsi/lms/" . $mode . "perform-registration.php>\n"
                     . "         <input type=hidden name=first_name value=$first_name>\n"
                     . "         <input type=hidden name=last_name value=$last_name>\n"
                     . "         <input type=hidden name=email_address value=$email_address>\n"
                     . "         <input type=hidden name=cert_num value=$cert_num>\n"
                     . "         <input type=hidden name=assert_email_address value=1>\n"
                     . "         <li><p>Press <input type=submit value=Continue> to use the email address as shown.</p></li>\n"
                     . "      </form>\n"
                     . "</ul>\n"
                     . "<p>If your email address is invalid, you will not receive any LMS account information.</p>\n"
                     . "</blockquote>\n"
                     . "</b>\n";
                  }
               }
            else
               {
               //
               // Fill the page out with an error message and instructions.
               //
               ?>
               <h2><i>Error!</i></h2>
               <b>
               <blockquote>
                  <p>One or more required parameters were missing or invalid.</p>
                  <p>Please press your browser's [<--&nbsp;BACK] button to correct the problems.</p>
               </blockquote>            
               </b>
               <?php
               }
            } // database up
         ?>
         <br>
         <hr>
         <p><small><small><i><pre>$Id$</pre></i></small></small>
      </td>
   </tr>
</table>
</body>
</html>
