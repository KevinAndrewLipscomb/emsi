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
//
// Initialize optional parameters.
//
$middle_initial = $street_address_2 = $zip = $phone = $other_certs = '';
//
// Accept user-supplied parameters and copy them into local variables.
//
import_request_variables('PG','_');
$first_name = $_first_name;
$middle_initial = $_middle_initial;
$last_name = $_last_name;
$cert_level = $_cert_level;
$email_address = $_email_address;
$cert_num = $_cert_num;
$month_of_birth = $_month_of_birth;
$day_of_birth = $_day_of_birth;
$year_of_birth = $_year_of_birth;
$street_address = $_street_address;
$street_address_2 = $_street_address_2;
$city = $_city;
$state = $_state;
$zip = $_zip;
$phone = $_phone;
$county = $_county;
$region = $_region;
$be_other_certs = $_be_other_certs;
$other_certs = $_other_certs;
$be_instructor = $_be_instructor;
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
                  ($cert_level != "")
               and
                  ($email_address != "")
               and
                  ($cert_num != "")
               and
                  (($month_of_birth >= 1) and ($month_of_birth <= 12))
               and
                  (($day_of_birth >= 1) and ($day_of_birth <= 31))
               and
                  ($year_of_birth >  1889)  // According to Guinness, all born before are dead.
               and
                  ($street_address != "")
               and
                  ($city != "")
               and
                  ($state != "")
               and
                  ($county != "")
               and
                  ($region != "")
               and
                  ($be_other_certs != "")
               and
                  ($be_instructor != "")
               )
            // then
               {
               mysql_query
                  (
                  "insert into " . $mode . "lms_applicant set first_name='$first_name' "
                  .  ", middle_name='$middle_initial' "
                  .  ", last_name='$last_name' "
                  .  ", cert_level='$cert_level' "
                  .  ", email_address='$email_address' "
                  .  ", cert_num='$cert_num' "
                  .  ", dob='$year_of_birth-$month_of_birth-$day_of_birth' "
                  .  ", street_address_1='$street_address' "
                  .  ", street_address_2='$street_address_2' "
                  .  ", city='$city' "
                  .  ", state='$state' "
                  .  ", zip_code='$zip' "
                  .  ", phone_num='$phone' "
                  .  ", county_of_residence='$county' "
                  .  ", regional_ems_council_code='$region' "
                  .  ", be_multiple_certs='$be_other_certs' "
                  .  ", comments='$other_certs' "
                  .  ", be_emt_instructor='$be_instructor' "
                  )
                  or die("Insert failed with error: " . mysql_error());
               echo "<b>Thanks!</b></p>\n";
               echo "<p>Your application has been registered in EMSI's database.  You should receive your account "
                  . "information within two weeks.</p>\n";
               echo "<ul>\n"
                  . "   <li><p><a href=http://www.emsi04.org/services/prehosp-pers/lms/>Return to EMSI's LMS page</a></p></li>\n"
                  . "   <li><p><a href=http://www.emsi04.org/>Return to EMSI's home page</a></p></li>\n"
                  . "</ul>\n";
               }
            else
               {
               //
               // Fill the page out with a warning and instructions.
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
