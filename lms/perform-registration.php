<?php
//
// $Id$
//
error_reporting(E_ALL);
//
// Determine, based on the name by which this file was invoked, whether or not to operate in production or test mode.
//
$foundation_dir = "../../foundation";
require_once("f_runmode.phtml");
$mode = RunMode($PHP_SELF);
//
require_once("$foundation_dir/f_bodyopen.phtml");
require_once("$foundation_dir/f_connectselectdb.phtml");
require_once("$foundation_dir/f_password.phtml");
//
// Initialize optional parameters.
//
$middle_name = $street_address_2 = $zip = $phone = $other_certs = '';
//
import_request_variables('PG');
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
               <td><img align="center" valign="middle" src="/graphics/logo.gif"></td>
               <td>
                  <h6 align="center">EMSI LAMPS Application Host at Oscarsystem.com</h6>
                  <h1>Learning Management System Registration</h1>
               </td>
            </tr>
         </table>
         <hr>
         <br>
         <?
         if (ConnectSelectDb("localhost","kalipso",Password(),"emsi") != "TRUE")
            {
            ?>
            <h2><i>Sorry...</i></h2>
            <b>
            <blockquote>
               <? echo "<p>The database is temporarily offline.&nbsp; Please try again later.</p>"; ?>
            </blockquote>            
            </b>
            <?
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
                  ($date_of_birth != "")
               and
                  ($street_address != "")
               and
                  ($city != "")
               and
                  ($state != "")
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
                  ($other_certs != "")
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
                  .  ", dob='$date_of_birth' "
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
                  <p>You did not supply one or more of the required parameters.&nbsp; You must supply values for these fields:</p>
                  <ul>
                     <li><p>First name</p>
                     <li><p>Last name</p>
                     <li><p>Email address</p>
                     <li><p>Certification #</p>
                     <li><p>Street address</p>
                     <li><p>City</p>
                     <li><p>State</p>
                     <li><p>County of residence</p>
                     <li><p>EMS region</p>
                     <li><p>Date of birth</p>
                     <li><p>Are you a certified EMT Instructor?</p>
                     <li><p>Do you hold any other DOH EMSO certifications?</p>
                  </ul>
                  <p>Please press your browser's [<--&nbsp;BACK] button to correct the problems.</p>
               </blockquote>            
               </b>
               <?
               }
            } // database up
         ?>
         <br>
         <hr>
         <p><small><small><i><pre>$Id$</pre></i></small></small>
      </td>
   </tr>
</table>
<b>Thanks!</b></p>
<p>Your application has been sent to EMSI's LMS Registration Coordinator.</p>
</body>
</html>
