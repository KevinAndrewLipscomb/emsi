use strict;
sub version_ca {
	return '2.0.0.0063';
	}

=head1 HEAD

Copyright 1997-2003 by Zoltan Milosevic, All Rights Reserved
See http://www.xav.com/scripts/search/ for more information.

If you edit the source code, you'll find it useful to restore the function comments and #&Assert checks:

	cd "search/searchmods/powerusr/"
	hacksubs.pl build_map
	hacksubs.pl restore_comments
	hacksubs.pl assert_on

common_admin.pl contains functions that are only called from the Mode/Admin or Mode/AnonAdd pathways.

=cut





sub ui_Rewrite {
	my $err = '';
	Err: {
		my $sa = $FORM{'sa'} || '';
		if ($sa eq 'save') {

print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=FilterRules">$str[162]</a> /
	<a href="$const{'admin_url'}&amp;Action=Rewrite">Rewrite</a> /
	$str[362]
</b></p>

EOM

			my $test_str = 'foo bar';


			my $level;
			foreach $level (0,1) {
				my @rules = ();
				foreach (sort keys %FORM) {
					next unless (m!^$level\.(\d+)$!);
					my $key = $1;

					my ($p1, $p2) = ($FORM{$key . '_p1'}, $FORM{$key . '_p2'});

					next unless ($p1);

					my @fields = ($FORM{$key . '_enabled'}, $p1, $p2, $FORM{$key . '_comment'}, $FORM{$key . '_verbose'} );

					eval '$test_str =~ s!$p1!$p2!isg;';
					if ($@) {
						my ($hp1, $hp2) = &he($p1, $p2);
						$err = "unable to evaluate Perl substitution on '$hp1' and '$hp2' - Perl returned the following error string:</p><p>" . &he($@);
						next Err;
						}


					my $str = join('=', map { &url_encode($_) } @fields );
					push(@rules, $str);
					}
				$err = &WriteRule( "rewrite_url_" . $level , join('&',@rules) );
				next Err if ($err);
				my $count = scalar @rules;
				print "<p><b>Success:</b> saved <b>$count</b> level-$level rewrite rules.</p>\n";
				}



			last Err;
			}

		my @out = ('', '');

my $template = <<"EOM";

<input type="hidden" name="%level%.%name%" value="1" />

<table border="1">
<tr>
	<th>Enabled</th>
	<th>$str[528]</th>
	<th>Pattern</th>
	<th>Replace</th>
</tr>
<tr>
	<td align="center"><input type="checkbox" value="1" name="%name%_enabled" /><input type="hidden" value="0" name="%name%_enabled_udav" /></td>
	<td align="center"><input type="checkbox" value="1" name="%name%_verbose" /><input type="hidden" value="0" name="%name%_verbose_udav" /></td>
	<td><input name="%name%_p1" /></td>
	<td><input name="%name%_p2" /></td>
</tr>
<tr class="%class%">
	<td colspan="2" align="right"><b>Comment:</b></td>
	<td colspan="2"><textarea name="%name%_comment" rows="2" cols="40"></textarea></td>
</tr>
</table>

<p><br /></p>

EOM

	# format is b_enabled,p1,p2,comment,b_verbose,

		my $index = 1000;

		my $level;
		foreach $level (0,1) {
			for (0..1) {
				$index++;
				my $frag = $template;
				$frag =~ s!%name%!$index!sg;
				$frag =~ s!%level%!$level!sg;
				$frag =~ s!%class%!newdata!sg;
				my %defaults = (
					$index . '_enabled' => 1,
					$index . '_comment' => 'new rewrite rule',
					);
				$out[$level] .= &SetDefaults($frag, \%defaults);
				}


			my @rules = ();
			my $key = "rewrite_url_" . $level;
			my $rule;
			foreach $rule (split(m!\&!, $Rules{$key})) {
				my @fields = map { &ud($_) } split(m!\=!, $rule);
				push(@rules, \@fields);
				}


			my $p_rule;
			foreach $p_rule (@rules) {
				$index++;
				my $frag = $template;
				$frag =~ s!%name%!$index!sg;
				$frag =~ s!%level%!$level!sg;
				$frag =~ s!%class%!existingdata!sg;
				my %defaults = (
					$index . '_enabled' => $$p_rule[0],
					$index . '_verbose' => $$p_rule[4],
					$index . '_p1' => $$p_rule[1],
					$index . '_p2' => $$p_rule[2],
					$index . '_comment' => $$p_rule[3],
					);
				$out[$level] .= &SetDefaults($frag, \%defaults);
				}
			for (0..1) {
				$index++;
				my $frag = $template;
				$frag =~ s!%name%!$index!sg;
				$frag =~ s!%level%!$level!sg;
				$frag =~ s!%class%!newdata!sg;
				my %defaults = (
					$index . '_enabled' => 1,
					$index . '_comment' => 'new rewrite rule',
					);
				$out[$level] .= &SetDefaults($frag, \%defaults);
				}
			}


print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=FilterRules">$str[162]</a> /
	<a href="$const{'admin_url'}&amp;Action=Rewrite">Rewrite</a> /
	Overview
</b></p>

$const{'AdminForm'}
<input type="hidden" name="Action" value="Rewrite" />
<input type="hidden" name="sa" value="save" />

		<p><b>Input Filters</b></p>

		<p>The following Perl substitutions will be performed, in order, on all links as they are extracted from files during a crawl session.</p>

		<p>If the <b>$str[528]</b> bit is set, then a statement will be printed to screen whenever the substitution is successful. Use this for testing.</p>

		<p>You may add new rewrite rules by using the first or last two blank tables. If you need to add more than that, simply enter two,
		then save, and then you will be able to add more. To delete a rule, delete the <b>Pattern</b> portion.</p>

		<p>Use the <b>Enabled</b> bit to turn rules on or off during development. Link extraction rewrite rules are part of the critical path and should only be enabled if needed.</p>

		$out[0]

		<p><b>Output Filters</b></p>

		<p>The following Perl substitutions will be performed, in order, on all links just before they are shown in the search results.</p>

		<p>If the <b>$str[528]</b> bit is set, then a statement will be printed to screen whenever the substitution is successful. Use this for testing.</p>

		$out[1]

<p><input type="submit" class="submit" value="$str[362]" /></p>

</form>


EOM

		last Err;
		}
	continue {
		&ppstr(64,$err);
		}
	}





sub ui_License {
	my $err = '';
	Err: {

		print "<p><b><a href=\"$const{'admin_url'}\" target=\"_top\">$str[96]</a> / <a href=\"$const{'admin_url'}&amp;Action=UL\">$str[467]</a> / ";

		my $sa = $FORM{'sa'} || '';
		if ($sa eq 'Write') {

			print "$str[362]</b></p>";

			if ($const{'mode'} == 0) {
				$err = $str[435];
				next Err;
				}

			if ($FORM{'regkey'}) {
				unless (&regkey_validate($FORM{'regkey'})) {
					$err = $str[454] . " (<a href=\"$const{'help_file'}1088.html\" target=\"_blank\">$str[432]</a>)";
					next Err;
					}
				}
			elsif ($FORM{'mode'} == 2) {
				$err = $str[455];
				next Err;
				}

			if ($FORM{'mode'} == 3) {
				if (1 < $realms->realm_count('all')) {
					$err = $str[456];
					next Err;
					}
				my $p_realm_data = ();
				foreach $p_realm_data ($realms->listrealms('all')) {
					if ($$p_realm_data{'type'} == 1) {
						$err = &pstr(457,$$p_realm_data{'html_name'});
						next Err;
						}
					elsif ($$p_realm_data{'type'} == 6) {
						$err = &pstr(529,$$p_realm_data{'html_name'});
						next Err;
						}
					}
				}
			if (($FORM{'regkey'}) and ('' eq $Rules{'regkey'})) {
				$FORM{'mode'} = 2;
				}
			$err = &WriteRule('mode', $FORM{'mode'});
			next Err if ($err);
			$err = &WriteRule('regkey', &url_encode($FORM{'regkey'}));
			next Err if ($err);
			&ppstr(174,$str[114]);
			last Err;
			}
		print "$str[152]</b></p>";

		my %defaults = (
			'mode' => $const{'mode'},
			'regkey' => &ud($Rules{'regkey'}),
			);

		$defaults{'regkey'} =~ s!(\015|\012|\r|\n)+!\015\012!sg;

print &SetDefaults(<<"EOM", \%defaults);

$const{'AdminForm'}
<input type="hidden" name="Action" value="UL" />
<input type="hidden" name="sa" value="Write" />

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$str[458]</th>
	<th>$str[447]</th>
</tr>
<tr class="fdtan" valign="top">
	<td><input type="radio" name="mode" value="3" id="mode_3" /></td>
	<td><label for="mode_3">$str[463]</label></td>
	<td>$str[459]</td>
</tr>
<tr class="fdtan" valign="top">
	<td><input type="radio" name="mode" value="1" id="mode_1" /></td>
	<td><label for="mode_1">$str[462]</label></td>
	<td>$str[460]</td>
</tr>
<tr class="fdtan" valign="top">
	<td><input type="radio" name="mode" value="2" id="mode_2" /></td>
	<td><label for="mode_2">$str[461]</label></td>
	<td>$str[468]</td>
</tr>
</table>

<p>$str[386]<br /><tt><textarea name="regkey" rows="10" cols="65"></textarea></tt></p>

<p><input type="submit" class="submit" value="$str[362]" /></p>

$str[446]

</form>

EOM
		last Err;
		}
	continue {
		&ppstr(64,$err);
		}
	}





sub parse_text_record {
	local $_ = defined($_[0]) ? $_[0] : '';
	my ($is_valid, %pagedata) = (0);
	if (m!^(\d\d)(\d\d)(\d\d)(\d\d\d\d)(\d+) (\d+) (\d+) u= (.+?) t= (.*?) d= (.*?) uM= (.*?) uT= (.*?) uD= (.*?) uK= (.*?) h= (.*?) l= (.*)!) {
		%pagedata = (
			'promote' => $1,
			'dd' => $2,
			'mm' => $3,
			'yyyy' => $4,
			'size' => 1 * $5,
			'lastmodtime' => $6,
			'lastindex' => $7,
			'url' => $8,
			'title' => $9,
			'description' => $10,
			'um' => $11,
			'ut' => $12,
			'ud' => $13,
			'keywords' => $14,
			'uk' => $14,
			'text' => $15,
			'links' => $16,
			);
		$is_valid = 1;
		}

#revcompat - older yet supported format

	elsif (m!^(\d\d)(\d\d)(\d\d)(\d\d\d\d)(\d+) u= (.+?) t= (.*?) d= (.*?) uM= (.*?) uT= (.*?) uD= (.*?) uK= (.*?) h= (.*?) l= (.*)!) {
		%pagedata = (
			'promote' => $1,
			'dd' => $2,
			'mm' => $3,
			'yyyy' => $4,
			'size' => 1 * $5,
			'url' => $6,
			'title' => $7,
			'description' => $8,
			'um' => $9,
			'ut' => $10,
			'ud' => $11,
			'keywords' => $12,
			'uk' => $12,
			'text' => $13,
			'links' => $14,
			);
		$is_valid = 1;
		}
#/revcompat

	return ($is_valid, %pagedata);
	}





sub check_db_config {
#db
	my ($verbose) = @_;
	my ($addr_count, $realmcount, $log_exists) = ('', 0, 0, 0);

	my $dbh = undef();
	my $sth = undef();

	my $err = '';
	Err: {
		$err = &get_dbh(\$dbh);
		next Err if ($err);

		my $mysql_ver = '';
		unless ($sth = $dbh->prepare('SELECT VERSION()')) {
			$err = $str[45] . ' ' . $dbh->errstr();
			next Err;
			}
		unless ($sth->execute()) {
			$err = $str[29] . ' ' . $sth->errstr();
			next Err;
			}
		if ($sth->rows()) {
			$mysql_ver = ($sth->fetchrow_array())[0];
			}
		$sth->finish();
		$sth = undef();

		&pppstr(167,$mysql_ver) if ($verbose);

		my %existing_tables = ();
		unless ($sth = $dbh->prepare('SHOW tables')) {
			$err = $str[45] . ' ' . $dbh->errstr();
			next Err;
			}
		unless ($sth->execute()) {
			$err = $str[29] . ' ' . $sth->errstr();
			next Err;
			}
		if ($sth->rows()) {
			my @data = ();
			while (@data = $sth->fetchrow_array()) {
				$existing_tables{$data[0]}++;
				}
			}
		$sth->finish();
		$sth = undef();

		if ($existing_tables{ $Rules{'sql: table name: logs'} }) {
			$log_exists = 1;
			}

		foreach ( $Rules{'sql: table name: realms'}, $Rules{'sql: table name: addresses'} ) {
			unless ($existing_tables{$_}) {
				$err = &pstr(161,$_);
				next Err;
				}
			}

		unless ($sth = $dbh->prepare("SELECT count(*) AS cnt FROM $Rules{'sql: table name: addresses'}")) {
			$err = $str[45] . ' ' . $dbh->errstr();
			next Err;
			}

		unless ($sth->execute()) {
			$err = $str[29] . ' ' . $sth->errstr();
			next Err;
			}

		my @data = $sth->fetchrow_array();
		$addr_count = $data[0];
		$sth->finish();
		$sth = undef();

		unless ($sth = $dbh->prepare("SELECT count(*) AS cnt FROM $Rules{'sql: table name: realms'}")) {
			$err = $str[45] . ' ' . $dbh->errstr();
			next Err;
			}

		unless ($sth->execute()) {
			$err = $str[29] . ' ' . $sth->errstr();
			next Err;
			}
		@data = $sth->fetchrow_array();
		$realmcount = $data[0];
		}
	$sth->finish() if ($sth);
	$dbh->disconnect() if ($dbh);
	return ($err, $addr_count, $realmcount, $log_exists);
#/db
	}





sub ui_FilterRules {

	my $subaction = $FORM{'subaction'} || '';

	my $ApproveLink = "<a href=\"$const{'admin_url'}&amp;Action=FilterRules&amp;subaction=ShowPending&amp;Realm=" . &url_encode( $FORM{'Realm'} ) . "\">$str[160]</a>";

	my %subactions = (
		'' => $str[152],
		'CreateEdit' => $str[412],
		'create_edit_rule' => $str[412],
		'delete_rule' => $str[413],
		'ShowPending' => $ApproveLink,
		'PQP' => $ApproveLink,
		'save_settings' => $str[362],
		);

	print "<p><b><a href=\"$const{'admin_url'}\" target=\"_top\">$str[96]</a> / <a href=\"$const{'admin_url'}&amp;Action=FilterRules\">$str[162]</a>";

	if ($subactions{$subaction}) {
		print " / $subactions{$subaction}";
		}

	print "</b></p>\n";

	my $err = '';
	Err: {
		local $_;

		if (($subaction eq 'CreateEdit') or ($subaction eq 'create_edit_rule')) {
			$err = &s_create_edit_rule();
			next Err if ($err);
			last Err;
			}

		if ($subaction eq 'ShowPending') {
			&present_queued_pages($FORM{'Realm'});
			last Err;
			}

		if ($subaction eq 'PQP') {
			&process_queued_pages();
			last Err;
			}

		my $fr = &fdse_filter_rules_new();

		if ($subaction eq 'delete_rule') {
			$err = $fr->delete_filter_rule($FORM{'name'});
			next Err if ($err);
			&ppstr(174,&pstr(414,&he($FORM{'name'})));
			print '<p>' . $str[519] . '</p>';
			last Err;
			}

		if ($subaction eq 'save_settings') {
			my $p_data = ();
			foreach $p_data ($fr->list_filter_rules()) {
				next if (($const{'mode'} == 3) and ($$p_data{'is_system'} == 0));
				my $name = $$p_data{'name'};
				if ($FORM{"$name-enabled"}) {
					$$p_data{'enabled'} = 1;
					}
				else {
					$$p_data{'enabled'} = 0;
					}
				}
			$err = $fr->frwrite();
			next Err if ($err);

			foreach ('allowanonadd', 'require anon approval', 'allowanonadd: notify admin', 'allowanonadd: require user email', 'allowanonadd: log') {
				if (not defined($FORM{$_})) {
					$err = "invalid argument. Required parameter '$_' is not defined";
					next Err;
					}
				$err = &WriteRule($_, $FORM{$_});
				next Err if ($err);
				}

			$FORM{'pics_rasci_enable'} = 0 unless ($FORM{'pics_rasci_enable'});
			$FORM{'pics_ss_enable'} = 0 unless ($FORM{'pics_ss_enable'});
			foreach (keys %FORM) {
				next unless (m!^pics_!);
				$err = &WriteRule($_, $FORM{$_} || 0);
				next Err if ($err);
				}
			&ppstr(174,$str[114]);
			last Err;
			}

print <<"EOM";

$const{'AdminForm'}
	<input type="hidden" name="Action" value="FilterRules" />
	<input type="hidden" name="subaction" value="save_settings" />

EOM

		my $str_rule_list = '';

		my @action_names = (
			$str[479], # always allow
			$str[142], # deny
			$str[478], # require approval
			$str[477], # promote
			$str[476], # no update on redirect
			$str[514], # index nofollow
			$str[515], # follow noindex
			);

		my $p_data = ();
		foreach $p_data ($fr->list_filter_rules()) {

			if ($const{'mode'} == 3) {
				next unless ($$p_data{'is_system'});
				}


			my $en = '';

			if ($$p_data{'enabled'}) {
				$en = ' checked="checked"';
				}

			my $urlname = &url_encode($$p_data{'name'});
			my $htmlname = &he($$p_data{'name'});
			my $action = $action_names[$$p_data{'action'}];

$str_rule_list .= <<"EOM";

<tr class="fdtan">
	<td><input type="checkbox" name="$htmlname-enabled" value="1"$en /></td>
	<td><b>$htmlname</b></td>
	<td><a href="$const{'admin_url'}&amp;Action=FilterRules&amp;subaction=CreateEdit&amp;name=$urlname" class="onbrown">$str[411]</a></td>
	<td>

EOM

			unless ($$p_data{'is_system'}) {
				$str_rule_list .= qq!<a href="$const{'admin_url'}&amp;Action=FilterRules&amp;subaction=delete_rule&amp;name=$urlname" onclick="return confirm('$str[108]');" class="onbrown">$str[430]</a>!;
				}

			my $scope = ($$p_data{'apply_to'} == 1) ? $str[535] : $str[534];

$str_rule_list .= <<"EOM";

	<br /></td>
	<td>$action</td>
	<td>$scope</td>
</tr>

EOM
			}

		my %replace = %const;
		$replace{'HTML_BLOCK_1'} = $str_rule_list;


		my $pics_type = 'RASCi';
		my $rulename = 'rasci';
		my $html = '';
		if ($Rules{'pics_' . $rulename . '_enable'}) {

$html .= sprintf(<<'EOM', $rulename, $str[415], $rulename, $str[416], $str[417]);

			<table border="0">
			<tr>
				<td><input type="radio" name="pics_%s_handle" value="0" /></td>
				<td>%s</td>
			</tr><tr>
				<td><input type="radio" name="pics_%s_handle" value="1" /></td>
				<td>%s</td>
			</tr>
			</table>

			<p>%s</p>

EOM

			my (@pics_codes, @pics_names, @pics_values) = ();
			my $load_err = &load_pics_descriptions( $pics_type, \@pics_codes, \@pics_names, \@pics_values );
			if ($load_err) {
				&ppstr(64,$load_err);
				}
			else {
				$html .= '<dl>';
				my $i = 0;
				for (0..$#pics_codes) {
					my $code = $pics_codes[$_];
					my $name = $pics_names[$_];
					my $p_values = $pics_values[$_];
					my @values = @$p_values;

					$html .= "<dt><b>PICS / $pics_type / $name</b></dt>\n";
					$html .= "<dd>\n";

					my $i = 0;
					foreach (@values) {
						$html .= sprintf('<input type="radio" name="pics_%s_%s" value="%d" /> (%s%d) %s<br />', $rulename, $code, $i, $code, $i, $_ );
						$i++;
						}
					$html .= "</dd>\n";
					}
				$html .= '</dl>';
				}
			}
		$replace{'HTML_BLOCK_2'} = $html;


		$pics_type = 'SafeSurf';
		$rulename = 'ss';
		$html = '';
		if ($Rules{'pics_' . $rulename . '_enable'}) {

$html .= sprintf(<<'EOM', $rulename, $str[415], $rulename, $str[416], $str[417]);

			<table border="0">
			<tr>
				<td><input type="radio" name="pics_%s_handle" value="0" /></td>
				<td>%s</td>
			</tr><tr>
				<td><input type="radio" name="pics_%s_handle" value="1" /></td>
				<td>%s</td>
			</tr>
			</table>

			<p>%s</p>

EOM

			my (@pics_codes, @pics_names, @pics_values) = ();
			my $load_err = &load_pics_descriptions( $pics_type, \@pics_codes, \@pics_names, \@pics_values );
			if ($load_err) {
				&ppstr(64,$load_err);
				}
			else {
				$html .= '<dl>';
				my $i = 0;
				for (0..$#pics_codes) {
					my $code = $pics_codes[$_];
					my $name = $pics_names[$_];
					my $p_values = $pics_values[$_];
					my @values = @$p_values;

					$html .= "<dt><b>PICS / $pics_type / $name</b></dt>\n";
					$html .= "<dd>\n";

					my $i = 0;
					foreach (@values) {
						$html .= sprintf('<input type="radio" name="pics_%s_%s" value="%d" /> %d. %s<br />', $rulename, $code, $i, $i, $_ );
						$i++;
						}
					$html .= "</dd>\n";
					}
				$html .= '</dl>';
				}
			}
		$replace{'HTML_BLOCK_3'} = $html;
		my $template = &PrintTemplate( 1, 'admin_fr.txt', $Rules{'language'}, \%replace );
		print &SetDefaults( $template, \%Rules );
		print "</form>";




		last Err;
		}
	continue {
		&ppstr(64,$err);
		}
	}





sub load_pics_descriptions {
	my $err = '';
	Err: {
		my ($pics_type, $p_codes, $p_names, $p_values) = @_;
		my $text = '';
		($err, $text) = &ReadFileL('templates/pics_descriptions.txt');
		next Err if ($err);
		my $current_code = '';
		my $p_myvalues = ();
		foreach (split(m!\n!s, $text)) {
			next if (m!^\#!);
			my @fields = split(m! \| !);
			next unless ($#fields == 4);
			if ($fields[0] eq $pics_type) {
				my ($code, $code_name, $value, $value_name) = @fields[1..4];
				if ($current_code ne $code) {
					$current_code = $code;
					push(@$p_codes, $code);
					push(@$p_names, $code_name);
					my @values = ();
					$p_myvalues = \@values;
					push(@$p_values, $p_myvalues);
					}
				$$p_myvalues[$value] = $value_name;
				}
			}
		}
	return $err;
	}





sub s_create_edit_rule {
	my $err = '';
	Err: {
		local $_;

		my $fr = &fdse_filter_rules_new();
		my %system_rules = $fr->list_system_rules();

		if ($const{'mode'} == 3) {
			unless (($FORM{'name'}) and ($system_rules{$FORM{'name'}})) {
				$err = $str[158];
				next Err;
				}
			}

		my %defaults = (
			'enabled' => 1,
			'fr_action' => 2,
			'fr_analyze' => 2,
			'fr_mode' => 0,
			'name' => 'New Rule',
			'occurrences' => 1,
			'promote_val' => 5,
			'substr' => '',
			'fr_apply_to' => 1,
			);

		if ($FORM{'write'}) {

			my @strings = ();
			foreach (split(m!\r|\n!, $FORM{'substr'})) {
				$_ = &Trim($_);
				next unless ($_);
				push(@strings, $_);
				}
			my @litstrings = ();
			foreach (split(m!\r|\n!, $FORM{'litsubstr'})) {
				$_ = &Trim($_);
				next unless ($_);
				push(@litstrings, $_);
				}

			my $apply_to_str = '';
			if ($FORM{'fr_apply_to'} eq '2') {
				for (1..6) {
					next unless ($FORM{"z$_"} eq '1');
					$apply_to_str .= "$_,";
					}
				}
			elsif ($FORM{'fr_apply_to'} eq '3') {
				foreach (keys %FORM) {
					next unless (m!^zz(.*)$!);
					$apply_to_str .= &url_encode($1) . ',';
					}
				}

			$err = $fr->add_filter_rule( $FORM{'enabled'}, $FORM{'name'}, $FORM{'fr_action'}, $FORM{'promote_val'}, $FORM{'fr_analyze'}, $FORM{'fr_mode'}, $FORM{'occurrences'}, $FORM{'fr_apply_to'}, $apply_to_str, \@strings, \@litstrings );
			next Err if ($err);
			if (($FORM{'orig_name'}) and ($FORM{'orig_name'} ne $FORM{'name'})) {
				$err = $fr->delete_filter_rule($FORM{'orig_name'});
				next Err if ($err);
				&ppstr(174, &pstr(465,&he($FORM{'orig_name'},$FORM{'name'})) );
				}
			&ppstr(174, &pstr(464,&he($FORM{'name'})) );
			print '<p>' . $str[519] . '</p>';
			last Err;
			}

		my $html_orig_name = '';

		if ($FORM{'name'}) {
			$html_orig_name = &he($FORM{'name'});
			my $p_data = $fr->{$FORM{'name'}};

			unless ('HASH' eq ref($p_data)) {
				$err = &pstr(55,&he($FORM{'name'}));
				next Err;
				}

			my $p_strings = $$p_data{'p_strings'};
			$defaults{'substr'} = join("\n", @$p_strings);

			my $p_litstrings = $$p_data{'p_litstrings'};
			$defaults{'litsubstr'} = join("\n", @$p_litstrings);

			foreach ('name', 'fr_action', 'promote_val', 'fr_analyze', 'fr_mode', 'enabled', 'occurrences', 'fr_apply_to') {
				my $name = $_;
				$name =~ s!^fr_!!o;
				$defaults{$_} = $$p_data{$name};
				}

			if ($$p_data{'apply_to'} eq '2') {
				my @realm_types = split(m!\,!, $$p_data{'apply_to_str'} );
				foreach (@realm_types) {
					next unless (m!^\d+$!);
					$defaults{"z$_"} = 1;
					}
				}
			elsif ($$p_data{'apply_to'} eq '3') {
				my @realms = split(m!\,!, $$p_data{'apply_to_str'} );
				foreach (@realms) {
					$_ = &ud($_);
					next unless ($_);
					$defaults{"zz$_"} = 1;
					}
				}


			}
		else {
			my $num = 1;
			my $p_data = ();
			foreach $p_data ($fr->list_filter_rules()) {
				if ($$p_data{'name'} =~ m!New Rule (\d+)!i) {
					$num = ($1 + 1) if ($1 >= $num);
					}
				}
			$defaults{'name'} = "New Rule $num";
			}

		my $name = $defaults{'name'};
		$name = &he( $name );

		my $name_form = qq!<input name="name" value="$name" size="40" />!;
		if ($system_rules{$name}) {
			$name_form = qq!<input type="hidden" name="name" value="$name" />$name!;
			}

print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="FilterRules" />
<input type="hidden" name="subaction" value="CreateEdit" />
<input type="hidden" name="write" value="1" />
<input type="hidden" name="orig_name" value="$html_orig_name" />

EOM

		my %replace = %const;
		$replace{'HTML_BLOCK_1'} = $name_form;

		my $i = 0;
		my $realm_list = '';
		my $p_realm_data = ();
		foreach $p_realm_data ($realms->listrealms('all')) {
			$i++;
			$realm_list .= qq!<input type="checkbox" name="zz$$p_realm_data{'html_name'}" value="1" id="zz$i" /> <label for="zz$i">$$p_realm_data{'html_name'}</label><br />\n!;
			}

		$replace{'HTML_BLOCK_2'} = $realm_list;

		my $template = &PrintTemplate( 1, 'admin_fr2.txt', $Rules{'language'}, \%replace );
		print &SetDefaults( $template, \%defaults );
		print "</form>";
		}
	return $err;
	}





sub process_queued_pages {

	my $Realm = $FORM{'Realm'};

	my %Process = ();

# Map
# 	Proc0 => Wait
#	Proc1 => Approve
#	Proc2 => Deny
#	Proc3 => Delete


	foreach (keys %FORM) {
		next unless (m!^R\d+$!);
		next unless ($FORM{$_} =~ m!^Proc(\d)_(.*)$!);
		$Process{$2} = $1;
		}

	my ($obj, $p_rhandle, $p_whandle) = ();
	my $obj_needs_closed = 0;

	my $err = '';
	Err: {

		my $p_realm_data = ();
		($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
		next Err if ($err);

		my ($name, $file) = ($$p_realm_data{'name'}, $$p_realm_data{'file'});

		$obj = &LockFile_new();
		($err, $p_rhandle, $p_whandle) = $obj->ReadWrite( "$file.need_approval" );
		next Err if ($err);
		$obj_needs_closed = 1;

		my %crawler_results = ();

		my $b_write_to_file = 0;

		while (defined($_ = readline($$p_rhandle))) {
			my @Fields = split(m!\|\|!);
			next unless ($#Fields > 4);
			# time, remote_host, error_msg, is_error, url, record, email

			my $URL = $Fields[4];

			if ($Process{$URL}) {


				my ($is_valid, %pagedata) = &parse_text_record( $Fields[5] );
				if ($is_valid) {
					&compress_hash( \%pagedata );
					}
				else {
					# init as clean hash; could be a delete command, which won't come with a full record; that's ok:
					%pagedata = ();
					}
				$pagedata{'url'} = $URL;
				$pagedata{'is_error'} = 0;
				$pagedata{'record'} = "$Fields[5]\n";


				# deny a valid entry
				if ($Process{$URL} == 2) {
					$pagedata{'is_error'} = 1;
					$crawler_results{$URL} = \%pagedata;
					$b_write_to_file = 1;
					next;
					}

				# Delete an invalid URL:
				elsif ($Process{$URL} == 3) {
					$pagedata{'is_error'} = 1;
					$crawler_results{$URL} = \%pagedata;
					$b_write_to_file = 1;
					next;
					}

				# allow a valid entry
				elsif ($Process{$URL} == 1) {
					$pagedata{'is_error'} = 0;
					$crawler_results{$URL} = \%pagedata;
					$b_write_to_file = 1;
					next;
					}
				}
			# those other records can just stay there:
			print { $$p_whandle } $_;
			}

		if ($b_write_to_file) {
			my ($total_records, $new_records, $updated_records, $deleted_records) = (0, 0, 0, 0);

			($err, $total_records, $new_records, $updated_records, $deleted_records) = &update_realm( $Realm, \%crawler_results );
			next Err if ($err);

			$err = $obj->Merge();
			$obj_needs_closed = 0;
			next Err if ($err);


			$realms->setpagecount($Realm, $total_records, 1);
			$err = &SaveLinksToFileEx( $p_realm_data, \%crawler_results );
			next Err if ($err);

			&pppstr(289, $total_records, $$p_realm_data{'html_name'}, $new_records, $updated_records, $deleted_records );
			}
		else {
			&pppstr(418);
			}

		my $URL = '';

		my @localname = (
			$str[426],
			$str[427],
			$str[142],
			$str[430],
			);

		foreach $URL (sort keys %crawler_results) {
			my $ref_pagedata = $crawler_results{$URL};
			if ($$ref_pagedata{'sub status msg'}) {
				&ppstr(174, "$localname[$Process{$URL}] URL '" . &he($URL) . "' - $$ref_pagedata{'sub status msg'}" );
				}
			else {
				&ppstr(174, "$localname[$Process{$URL}] URL '" . &he($URL) . "'" );
				}
			}

		last Err;
		}
	continue {
		&ppstr(64,$err);
		}

	# If something went wrong, then close the file without committing changes:
	if ($obj_needs_closed) {
		$err = $obj->Cancel();
		if ($err) {
			&ppstr(64,$err);
			}
		}

	}





sub present_queued_pages {
	my $err = '';
	Err: {
		my ($Realm) = @_;

		my $Start = ($FORM{'Start'}) ? $FORM{'Start'} : 1;

		my $End = $Start + $Rules{'crawler: max pages per batch'} - 1;

		my $p_realm_data = ();
		($err, $p_realm_data) = $realms->hashref( $Realm );
		next Err if ($err);

		my $file = $$p_realm_data{'file'};

		my $display_html = '';

		my $Count = 0;

		my $obj = &LockFile_new();
		my $p_rhandle = ();
		($err, $p_rhandle) = $obj->Read( "$file.need_approval" );
		next Err if ($err);

		my %shown_urls = ();

		my @allow_change = ();

		while (defined($_ = readline($$p_rhandle))) {
			my @Fields = split(m!\|\|!, &Trim($_));
			# time, remote_host, error_msg, is_error, url, record, email

			my $URL = $Fields[4];

			# just show these guys once; skip duplicates
			next if ($shown_urls{$URL});
			$shown_urls{$URL}++;

			my $html_status = '';

			my ($index_time, $index_host, $index_error) = ($Fields[0], $Fields[1], $Fields[2]);

			my $str_index_time = &FormatDateTime( $index_time, $Rules{'ui: date format'} );

			my ($t1, $t2) = ('Allow', 'Deny');

			my $is_error = ($Fields[3]) ? 1 : 0;

			my %pagedata = ();

			unless ($is_error) {
				my $is_valid = 1;
				($is_valid, %pagedata) = &parse_text_record( $Fields[5] );
				next unless ($is_valid);
				}

			$Count++;

			next if ($Count < $Start);
			next if ($Count > $End);

			my $html_url = &he( $URL );

			my $user_html = '';
			if ($Fields[6]) {
				my $user_email = &he( $Fields[6] );
				$user_html = " - <a href=\"mailto:$user_email\">$user_email</a>";
				}

			if ($is_error) {

				$html_status = &StandardVersion(
					0,
					'rank' => $Count,
					'url' => $URL,
					'title' => "Remove: " . &he($URL),
					'description' => $Fields[2],
					);
				($t1, $t2) = ('Remove', 'Ignore');

				my $text_user = &pstr(419, $index_host);

$display_html .= <<"EOM";

		<p>$str_index_time - $text_user $user_html.</p>
		<p>$index_error</p>
		<table border="0">
		<tr>
			<td valign="top" width="120"><input type="radio" name="R$Count" value="Proc3_$html_url" checked="checked" /> $str[430]</td>
			<td valign="top">$html_status</td>
		</tr>
		</table>
		<hr size="1" />

EOM


				}
			else {

				$html_status = &AdminVersion(
					'rank' => $Count,
					%pagedata,
					);

				push(@allow_change, $Count);

				my $text_user = &pstr(419,$index_host);


$display_html .= <<"EOM";

		<p>$str_index_time - $text_user $user_html.</p>
		<p>$index_error</p>
		<table border="0">
		<tr>
			<td valign="top" width="120" nowrap="nowrap">
				<input type="radio" name="R$Count" value="Proc0_$html_url" checked="checked" /> $str[426]<br />
				<input type="radio" name="R$Count" value="Proc1_$html_url" /> $str[427]<br />
				<input type="radio" name="R$Count" value="Proc2_$html_url" /> $str[142]</td>
			<td valign="top">$html_status</td>
		</tr>
		</table>
		<hr size="1" />

EOM
				}
			}
		$err = $obj->Close();
		next Err if ($err);

		if ($Start > $Count) {
			&pppstr(420);
			}
		else {

			my $link = "$const{'admin_url'}&amp;Realm=" . &url_encode( $Realm ) . "&amp;Action=$FORM{'Action'}&amp;subaction=ShowPending&amp;Start=";
			my ($jump_sum, $jumptext) = &str_jumptext( $Start, $Rules{'crawler: max pages per batch'}, $Count, $link, 1 );
			print $jump_sum;
			print $jumptext;

			my $is_okay = (scalar @allow_change) ? 'true' : 'false';

print <<"EOM";

$const{'AdminForm'}
		<input type="hidden" name="Action" value="FilterRules" />
		<input type="hidden" name="subaction" value="PQP" />
		<input type="hidden" name="Realm" value="$Realm" />

		<script type="text/javascript">
		<!--
		var okay = false;
		if ((document) && (document.F1)) {
			okay = $is_okay;
			}
		function SetDef (x) {
			if (okay) {
EOM

			foreach (@allow_change) {
				print "\t\tif (document.F1.R$_) { document.F1.R" . $_ . "[x].checked = true; }\n";
				}

print <<"EOM";
				}
			}
		//--></script>

		<p><b>$str[421] - '$Realm'</b></p>

		<p><input type="submit" class="submit" value="$str[362]" /></p>

		<script type="text/javascript">
		<!--
		if (okay) {
			document.write("<p>[$str[148] <a href=javascript:SetDef(0)>$str[426]</a> - <a href=javascript:SetDef(1)>$str[427]</a> - <a href=javascript:SetDef(2)>$str[142]</a> ]</p>");
			}
		//-->
		</script>

		<hr size="1" />

		$display_html

		<script type="text/javascript">
		<!--
		if (okay) {
			document.write("<p>[ $str[148] <a href=javascript:SetDef(0)>$str[426]</a> - <a href=javascript:SetDef(1)>$str[427]</a> - <a href=javascript:SetDef(2)>$str[142]</a> ]</p>");
			}
		//-->
		</script>

		<p><input type="submit" class="submit" value="$str[362]" /></p>

		<p><b>$str[430]</b> - $str[423].<br />
		<b>$str[142]</b> - $str[423].<br />
		<b>$str[427]</b> - $str[424]<br />
		<b>$str[426]</b> - $str[425]</p>
		<p>$str[422]</p>

		</form>

EOM

			print $jumptext;
			}
		last Err;
		}
	continue {
		&ppstr(64,$err);
		}
	}





sub anonadd_main {
	my $err = '';
	Err: {
		if (($Rules{'allowanonadd'} == 0) or (0 == $realms->realm_count('has_no_base_url')) or ($const{'mode'} == 3)) {
			$err = $str[173];
			next Err;
			}

		if ((defined($FORM{'Realm'})) and (defined($FORM{'URL'}))) {
			$err = &s_AddURL(1, $FORM{'Realm'}, $FORM{'URL'});
			next Err if ($err);
			}

		my ($count, $html_hidden, $html_tr) = $realms->html_select_ex('is_open_realm', $FORM{'Realm'} );

		$FORM{'URL'} = $FORM{'URL'} || 'http://';

		my $input = '<input name="URL" size="40" id="fdse_URL" />';
		if ($Rules{'multi-line add-url form - visitors'}) {
			$input = '<textarea name="URL" rows="3" cols="40" style="wrap:soft" id="fdse_URL"></textarea>';
			}

		my $hidden = '';
		my ($n, $v);
		while (($n, $v) = &he(each %FORM)) {
			next unless ($n =~ m!^p:!);
			$hidden .= qq!<input type="hidden" name="$n" value="$v" />\n!;
			}

		if (($Rules{'default search terms'}) and (not ($FORM{'EMAIL'}))) {
			$FORM{'EMAIL'} = 'you@yourhost.tld';
			}

print &SetDefaults( <<"EOM", \%FORM );

<p><b>$str[172]</b></p>
<blockquote>
	<form method="post" action="$const{'script_name'}">
	<input type="hidden" name="Mode" value="AnonAdd" />
	$hidden
	$html_hidden

	<p>$str[288]</p>
	<table border="0">
	<tr>
		<td align="right"><b><label for="fdse_URL">$str[74]:</label></b></td>
		<td>$input</td>
	</tr>
	<tr>
		<td align="right"><b><label for="fdse_EMAIL">$str[206]:</label></b></td>
		<td><input name="EMAIL" size="40" id="fdse_EMAIL" /></td>
	</tr>
$html_tr
	<tr>
		<td><br /></td>
		<td><input type="submit" class="submit" value="$str[172]" /></td>
	</tr>
	</table>

	</form>
</blockquote>

EOM
		last Err;
		}
	return $err;
	}





sub admin_main {
	my $err = '';
	Err: {
		local $_;

		#changed 0056
		IPLimit: {

			last IPLimit unless (($private{'visitor_ip_addr'}) and ($private{'allow_admin_access_from'}));

			# patterns must be of the format a.b.c.d or a.b.c.* or a.b.* or a.*
			if ($private{'allow_admin_access_from'} =~ m![^0-9\.\s\*]!) {
				my $hstr = &he($private{'allow_admin_access_from'});
				$err = "string 'allow_admin_access_from' can only contain numbers, spaces, dots, and asterisks. An example of a valid string is '123.45.6.*'. Your string is currently set to '$hstr' which includes characters from outside the allowed set";
				next Err;
				}
			my @patterns = split(m!\s+!, $private{'allow_admin_access_from'});
			foreach (@patterns) {
				s!\.!\\\.!g;
				s!\*!\.\*!g;
				last IPLimit if ($private{'visitor_ip_addr'} =~ m!^$_$!);
				}
			$err = "access denied to admin functions. Your IP address $private{'visitor_ip_addr'} is not among the list of allowed addresses. The list of allowed addresses is controlled with the 'allow_admin_access_from' variable within the source code";
			next Err;
			}


		$| = 1;

		my $action = $FORM{'Action'} || '';

		if ($action ne 'NavBar') {
			#changed 0045 -- is this folder writable?
			my $w_test = 'is_writable.txt';
			if ((-e $w_test) and (not unlink($w_test))) {
				$err = &pstr(54, $w_test, $!);
				next Err;
				}
			unless (open( FILE, ">$w_test" )) {
				$err = &pstr(472, $!);
				next Err;
				}
			close(FILE);
			unlink($w_test);
			}

		#end changes

		print "HTTP/1.0 200 OK\015\012" if ($private{'PRINT_HTTP_STATUS_HEADER'});

		$const{'is_cmd'} = (($FORM{'interface'}) and ($FORM{'interface'} eq 'cmdline')) ? 1 : 0;
		if ($FORM{'fdrk_audit'}) { &regkey_verify(); last Err; }
		my ($is_auth, $form_password, $url_password) = &Authenticate( $Rules{'password'} );
		last Err unless ($is_auth);

		# Initialize network client cache:
		my %nc_cache = ();
		$const{'p_nc_cache'} = \%nc_cache;

		$const{'AdminForm'} = qq!<form method="post" action="$const{'script_name'}" name="F1">\n<input type="hidden" name="Mode" value="Admin" />\n$form_password!;

		$const{'admin_url'} .= $url_password;

		if ($ENV{'FDSE_NO_EXEC'}) {
			eval 'eval $FDSE_CALLBACK_SUB;';
			last Err;
			}

		my %admin_replace = %const;
		$admin_replace{'trans_credits'} = $str[502];

		$FORM{'nf'} = $FORM{'nf'} ? 1 : 0;
		if (($ENV{'HTTP_HOST'}) and ($ENV{'HTTP_HOST'} =~ m!\.netfirms\.com$!)) { # hack
			$FORM{'nf'} = 1;
			}
		my $use_frames = (($FORM{'nf'}) or ($Rules{'no frames'})) ? 0 : 1;

		unless ($use_frames) {
			$const{'admin_url'} .= '&nf=' . $FORM{'nf'};
			$const{'AdminForm'} .= qq!<input type="hidden" name="nf" value="$FORM{'nf'}" />\n!;
			}

		print "Content-Type: text/html\015\012" unless ($const{'is_cmd'});
		delete $private{'needs_header'};

		if ($use_frames) {

			my $nav_scroll = ''; #' scrolling="yes"';

			unless ($action) {
				my $act = $FORM{'A2'} || 'AdminPage';

printf("Cache-Control: max-age=%d, private\015\012\015\012", 60 * $Rules{'security: session timeout'} );
print <<"EOM";
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
<html>
<head>
	<title>FDSE: Admin Page</title>
	<meta http-equiv="Content-Type" content="$const{'content_type'}" />
	<meta name="robots" content="none" />
</head>
EOM

if ($const{'dir'} eq 'ltr') {
print <<"EOM";
<frameset cols="$str[184],*">
	<frame name="n" src="$const{'admin_url'}&amp;Action=NavBar"$nav_scroll />
	<frame name="m" src="$const{'admin_url'}&amp;dir=$const{'dir'}&amp;Action=$act" scrolling="yes" />
EOM
} else {
print <<"EOM";
<frameset cols="*,$str[184]">
	<frame name="m" src="$const{'admin_url'}&amp;dir=$const{'dir'}&amp;Action=$act" scrolling="yes" />
	<frame name="n" src="$const{'admin_url'}&amp;Action=NavBar"$nav_scroll />
EOM
}
print <<"EOM";
	<noframes>
		<body dir="$const{'dir'}"><p>Login successful. Click to <a href="$const{'admin_url'}&amp;nf=1">visit admin page</a>.</p></body>
	</noframes>
</frameset>
</html>

EOM
				last Err;
				}
			}

		if ($action eq 'NavBar') {
			printf("Cache-Control: max-age=%d, private\015\012\015\012", 60 * $Rules{'security: session timeout'} );
			$admin_replace{'copyright'} =~ s!<a href!<a class="onbrown" href!;
			&PrintTemplate( 0, 'admin_navbar.txt', $Rules{'language'}, \%admin_replace );
			last Err;
			}

		print "\015\012" unless ($const{'is_cmd'});

		$admin_replace{'ue_msg'} = &pstr(536, "$const{'help_file'}1162.html" );
		$admin_replace{'ue_msg'} =~ s!\"!\\\"!g; # escape quotes " for Javascript

		if (not $const{'is_cmd'}) {
			my $header = &PrintTemplate( 1, 'admin_template.html', $Rules{'language'}, \%admin_replace );
			if ($header =~ m!^(.*)%script_output%(.*)$!s) {
				($header, $private{'html_footer'}) = ($1, $2);
				}
			print $header;
			}

		$| = 0;

		unless ($use_frames) {
			$const{'copyright'} =~ s!<br />! !g;
			$private{'html_footer'} = $const{'copyright'} . $private{'html_footer'};

print <<"EOM";

<table border="1" cellpadding="4" cellspacing="1">
<tr valign="top" class="fdtan">
<td>
	<a href="$const{'admin_url'}" target="_top" class="onbrown">$str[96]</a>
</td><td>
	<a href="$const{'admin_url'}&amp;Action=ManageRealms" class="onbrown">$str[520]</a><br />
	<a href="$const{'admin_url'}&amp;Action=FilterRules" class="onbrown">$str[162]</a><br />
	<a href="$const{'admin_url'}&amp;Action=manage_data_storage" class="onbrown">$str[292]</a><br />
</td><td>
	<a href="$const{'admin_url'}&amp;Action=AdPage" class="onbrown">$str[145]</a><br />
	<a href="$const{'admin_url'}&amp;Action=ViewLog" class="onbrown">$str[106]</a><br />
	<a href="$const{'admin_url'}&amp;Action=UL" class="onbrown">$str[467]</a><br />
</td><td>
	<a href="$const{'admin_url'}&amp;Action=UserInterface" class="onbrown">$str[165]</a><br />
	<a href="$const{'admin_url'}&amp;Action=GeneralRules" class="onbrown">$str[159]</a><br />
	<a href="$const{'admin_url'}&amp;Action=PS" class="onbrown">$str[183]</a><br />
</td><td>
	<a href="$const{'help_file'}" class="onbrown">$str[432]</a><br />
	<a href="$const{'script_name'}" class="onbrown">$str[433]</a><br />
	<a href="$const{'admin_url'}&amp;Action=LogOut" class="onbrown">$str[434]</a><br />
</td>
</tr>
</table>

EOM
			}


		if ($action =~ m!^Add\s?URL$!) {

			# allow for single URL, this will need to be cleaned up.

			my @addresses_to_index = ();

			if (defined($FORM{'URL'})) {
				push(@addresses_to_index, $FORM{'URL'});
				}
			else {
				while (defined($_ = each %FORM)) {
					next unless (m!^(A|AddLink)\d+$!);
					push(@addresses_to_index, $FORM{$_});
					}
				}
			if (($FORM{'EntireSite'}) and ('1' eq $FORM{'EntireSite'})) {
				$FORM{'StartTime'} = $private{'script_start_time'} - 5;
				$action = $FORM{'Action'} = 'CrawlEntireSite';
				$FORM{'LimitPattern'} = '^' . quotemeta(&get_web_folder($FORM{'URL'}));
				}
			$err = &s_AddURL(0, $FORM{'Realm'}, @addresses_to_index);
			next Err if ($err);
			}
		elsif ($action eq 'Rewrite') {
			&ui_Rewrite();
			}
		elsif ($action eq 'UL') {
			&ui_License();
			}
		elsif ($action eq 'Review') {
			&ui_ReviewIndex();
			}
		elsif ($action eq 'SI') {
			&ui_sysinfo();
			}
		elsif ($action eq 'TXPDF') {
			$err = &ui_testxpdf();
			next Err if ($err);
			}
		elsif ($action eq 'rebuild') {
			&ui_Rebuild();
			}
		elsif ($action eq 'CrawlEntireSite') {
			&s_CrawlEntireSite($FORM{'Realm'});
			}
		elsif ($action eq 'ViewLog') {
			&ui_ViewStats();
			}
		elsif ($action eq 'UserInterface') {
			&ui_UserInterface();
			}
		elsif ($action eq 'Edit') {
			&ui_EditRecord();
			}
		elsif ($action eq 'DeleteRecord') {
			&ui_DeleteRecord();
			}
		elsif ($action eq 'FilterRules') {
			&ui_FilterRules();
			}
		elsif ($action eq 'GeneralRules') {
			&ui_GeneralRules();
			}
		elsif ($action eq 'manage_data_storage') {
			&ui_DataStorage();
			}
		elsif ($action eq 'AdPage') {
			$err = &ui_ManageAds();
			next Err if ($err);
			}
		elsif ($action eq 'AddForbidSite') {
			my $fr = &fdse_filter_rules_new();
			my $p_data = $fr->{'Forbid Sites'};
			my $p_array = ($FORM{'URL'} =~ m!\.\*!) ? $$p_data{'p_strings'} : $$p_data{'p_litstrings'};
			push(@$p_array,$FORM{'URL'});
			$err = $fr->frwrite();
			next Err if ($err);

print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=DeleteRecord">$str[95]</a>
</b></p>


EOM
			&ppstr(174, &pstr(466,&he($FORM{'URL'})) );
			}
		elsif ($action eq 'PS') {
			&ui_PersonalSettings();
			}
		elsif ($action eq 'ManageRealms') {
			$err = &ui_ManageRealms();
			next Err if ($err);
			}
		else {
			&ui_AdminPage();
			}
		last Err;
		}
	return $err;
	}





sub get_web_folder {
	my ($err, $clean, $host, $port, $path, $query, $frag, $folder) = &uri_parse(@_);
	return $folder;
	}





sub ui_ManageAds {
	my $err = '';
	Err: {
		my $subaction = $FORM{'SA'} || '';

		my %sub_desc = (
			'' => $str[152],
			'RC' => $str[147],
			'WA' => $str[362],
			);

print <<"EOM";

<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=AdPage">$str[145]</a> /
		$sub_desc{$subaction}</b></p>

EOM

		my $default_text = qq~<p align="center"><!-- $str[143] --></p>~;

		if ($const{'mode'} == 3) {
			$err = $str[158];
			next Err;
			}

		if ($subaction eq 'RC') {
			# clear everything:

			my $curtime = time();

			my ($obj, $p_rhandle, $p_whandle) = ();
			$obj = &LockFile_new(
				'create_if_needed' => 1,
				);
			($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('ads.xml');
			next Err if ($err);
			while (defined($_ = readline($$p_rhandle))) {
				s!start_date\=\"(.*?)\"!start_date\=\"$curtime\"!mg;
				print { $$p_whandle } $_;
				}
			$err = $obj->Merge();
			next Err if ($err);

			unless (opendir(DIR,'.')) {
				$err = &pstr(91,'.',$!);
				next Err;
				}
			foreach (readdir(DIR)) {
				next unless (m!^ads_hitcount_\d+\.txt$!);
				$err = &WriteFile($_,0);
				next Err if ($err);
				}
			closedir(DIR);
			&ppstr(174,$str[129]);
			last Err;
			}

		# Load ad info from file:

		my ($place_str, $body_str, @p_Ads) = ('', '');

		my $FileText = '<FDSE:Ads placement=" 2 3 4"></FDSE:Ads>'; # default
		if (-e 'ads.xml') {
			($err, $FileText) = &ReadFile('ads.xml');
			next Err if ($err);
			}
		$FileText =~ s!\015|\012! !sg;

		my $ads_ver = 1;
		if ($FileText =~ m! version=\"(\d+)!s) {
			$ads_ver = $1;
			}

		if ($FileText =~ m!<FDSE:Ads placement="(.*?)"!) {
			$place_str = $1;
			}
		if ($FileText =~ m!<FDSE:Ads.*?>(.*)</FDSE:Ads>!s) {
			$body_str = $1;
			}

		foreach (split(m!<FDSE:Ad !, $FileText)) {
			next unless m!(.*?)>(.*)</FDSE:Ad>!;
			my $strParams = $1;
			my %Params = ();
			if ($ads_ver > 1) {
				$Params{'='} = &Trim(&ud($2));
				}
			else {
				$Params{'='} = &Trim($2);
				}
			while ($strParams =~ m!^\s*(.*?)=\"(.*?)\"(.*)$!) {
				if ($ads_ver > 1) {
					$Params{&ud($1)} = &ud($2);
					}
				else {
					$Params{$1} = $2;
					}
				$strParams = $3;
				}
			push(@p_Ads, \%Params);
			}



		if ($subaction eq 'save-ads') {
			my $new = qq!<FDSE:Ads placement="$place_str">\015\012!;
			my $record = "\t" . '<FDSE:Ad version="2.0" ident="%d" weight="%d" keywords="%s" start_date="%d" placement="%s" kw="%d">' . "\015\012\t\t" . '%s' . "\015\012\t" . '</FDSE:Ad>' . "\015\012";
			my $i = 1;
			while (defined($FORM{"weight_$i"})) {
				my $AdText = &Trim($FORM{"content_$i"});
				$AdText =~ s!\015|\012! !mg;
				if (($AdText) and ($AdText ne $default_text)) {
					my $Advert = $p_Ads[$i - 1];
					my $start_date = time();
					if (($Advert) and ($$Advert{'start_date'})) {
						$start_date = $$Advert{'start_date'};
						}
					my $pos_str = '';
					for (1..4) {
						$pos_str .= " $_" if ($FORM{"pos:$i:$_"});
						}
					$new .= sprintf( $record, int($i), int($FORM{"weight_$i"}) || 0, &url_encode($FORM{"keywords_$i"}), int($start_date) || 0, &url_encode($pos_str), int($FORM{"kw_$i"}) || 0, &url_encode($AdText) );
					}
				$i++;
				}
			$new .= '</FDSE:Ads>';
			$err = &WriteFile('ads.xml',$new);
			next Err if ($err);
			&ppstr(174,$str[114]);
			last Err;
			}
		if ($subaction eq 'save-pos') {
			$err = &WriteRule('ui: search form display', 2 * $FORM{'sfp2'} + $FORM{'sfp1'} );
			next Err if ($err);
			my $new = '<FDSE:Ads placement="';
			for (1..4) {
				$new .= " $_ " if ($FORM{"adplace$_"});
				}
			$new .= "\">\015\012";
			$new .= $body_str;
			$new .= '</FDSE:Ads>';
			$err = &WriteFile('ads.xml',$new);
			next Err if ($err);
			&ppstr(174,$str[114]);
			last Err;
			}









		my %replace = %const;
		$replace{'total_ads'} = scalar @p_Ads;
		$replace{'total_positions'} = 0;

		my %defaults = ();

		for (1..4) {
			if ($place_str =~ m!$_!) {
				$defaults{"adplace$_"} = 1;
				$replace{'total_positions'}++;
				}
			}


		my $CurAdsText = '';
		my $demo_ads = '';

		my $OldestTime = 0;
		my $TotalImp = 0;

		my $AdId = 0;
		my $Advert;
		foreach $Advert (@p_Ads) {
			my $AdText = &he($$Advert{'='});

			$AdId++;

			my $imp = 0;
			if (open( FILE, "<ads_hitcount_$AdId.txt" )) {
				$imp = $1 if (<FILE> =~ m!(\d+)!);
				close(FILE);
				}
			$TotalImp += $imp;

			if ($OldestTime == 0) {
				$OldestTime = $$Advert{'start_date'};
				}
			elsif ($OldestTime > $$Advert{'start_date'}) {
				$OldestTime = $$Advert{'start_date'};
				}

			my $StartDate = &FormatDateTime( $$Advert{'start_date'}, $Rules{'ui: date format'} );

			my $str_ago = &get_age_str( time() - $$Advert{'start_date'} );
			my $imp_rate = &FormatNumber( (86400 * $imp / ( 1 + time() - $$Advert{'start_date'} ) ), 4, 1, 0, 1, $Rules{'ui: number format'} );

			my %record_defaults = (
				"keywords_$AdId" => $$Advert{'keywords'} || '',
				"kw_$AdId"    => $$Advert{'kw'} || 0,
				"weight_$AdId"  => $$Advert{'weight'} || 0,
				"content_$AdId" => $$Advert{'='} || '',
				);

			my @ch = ('','','','','');
			for (1..4) {
				$record_defaults{"pos:$AdId:$_"} = (($$Advert{'placement'}) and ($$Advert{'placement'} =~ m!$_!)) ? 1 : 0;
				}

			my $description = &pstr(101, $imp, $StartDate, $str_ago );
			$description .= "<br />" . &pstr(149, $imp_rate );

			my $show = $$Advert{'='};

			$demo_ads .= <<"EOM";

<table border="1" cellspacing="1" cellpadding="2" width="650">
<tr class="fdblue">
	<td><b>$AdId.</b></td>
</tr>
<tr class="data1">
	<td>$show</td>
</tr>
</table>

<p><br /></p>


EOM

			$CurAdsText .= &SetDefaults(<<"EOM", \%record_defaults);

<table border="1" cellspacing="1" cellpadding="2">
<tr class="fdblue">
	<td><b>$AdId.</b> $description<br />
	$str[151]: <tt><input name="keywords_$AdId" /></tt>
	$str[150]: <tt><input name="weight_$AdId" size="4" style="text-align:right" /></tt><br />
	<input type="radio" name="kw_$AdId" value="0" id="kw_0_$AdId" /> <label for="kw_0_$AdId">$str[370]</label><br />
	<input type="radio" name="kw_$AdId" value="1" id="kw_1_$AdId" /> <label for="kw_1_$AdId">$str[361]</label><br />
	$str[363]:
			1.<input type="checkbox" name="pos:$AdId:1" value="1" />
			2.<input type="checkbox" name="pos:$AdId:2" value="1" />
			3.<input type="checkbox" name="pos:$AdId:3" value="1" />
			4.<input type="checkbox" name="pos:$AdId:4" value="1" />
	</td>
</tr>
<tr class="fdblue">
	<td><tt><textarea name="content_$AdId" rows="4" cols="80" style="wrap:soft"></textarea></tt></td>
</tr>
</table>

<p><br /></p>

EOM
		}
	$AdId++;
	my $x3 = 0;
	my $html_default_text = &he($default_text);
	for $x3 ($AdId, ($AdId + 1)) {
		$CurAdsText .= <<"EOM";

<table border="1" cellspacing="1" cellpadding="2">
<tr class="fdblue">
	<td><b>$str[364]</b><br />
	$str[151]: <tt><input name="keywords_$x3" /></tt>
	$str[150]: <tt><input name="weight_$x3" value="100" size="4" style="text-align:right" /></tt><br />
	<input type="radio" name="kw_$x3" value="0" id="kw_0_$x3" checked="checked" /> <label for="kw_0_$x3">$str[370]</label><br />
	<input type="radio" name="kw_$x3" value="1" id="kw_1_$x3" /> <label for="kw_1_$x3">$str[361]</label><br />
	$str[363]:
			1.<input type="checkbox" name="pos:$x3:1" checked="checked" />
			2.<input type="checkbox" name="pos:$x3:2" checked="checked" />
			3.<input type="checkbox" name="pos:$x3:3" checked="checked" />
			4.<input type="checkbox" name="pos:$x3:4" checked="checked" />
	</td>
</tr>
<tr class="fdblue">
	<td><tt><textarea name="content_$x3" rows="4" cols="80" style="wrap:soft">$html_default_text</textarea></tt></td>
</tr>
</table>

<p><br /></p>

EOM
			}
		unless (($replace{'total_ads'}) and ($replace{'total_positions'})) {
			&ppstr(53,$str[262]);
			}
		elsif ($TotalImp) {
			my $StartDate = &FormatDateTime( $OldestTime, $Rules{'ui: date format'} );
			my $str_ago = &get_age_str( time() - $OldestTime );
			my $imp_rate = &FormatNumber( ( 86400 * $TotalImp / ( 1 + time() - $OldestTime ) ), 4, 1, 0, 1, $Rules{'ui: number format'} );
			my $description = &pstr(101, $TotalImp, $StartDate, $str_ago );
			$description .= '<br />' . &pstr(149, $imp_rate );
			print "<p>$description</p>\n";
			}
		$replace{'HTML_BLOCK_1'} = $CurAdsText;
		$replace{'HTML_BLOCK_2'} = $demo_ads;
		$defaults{'sfp1'} = $Rules{'ui: search form display'} % 2;
		$defaults{'sfp2'} = ($Rules{'ui: search form display'} < 2) ? 0 : 1;
		my $template = &PrintTemplate( 1, 'admin_ads.txt', $Rules{'language'}, \%replace );
		print &SetDefaults($template,\%defaults);
		last Err;
		}
	return $err;
	}





sub create_db_config {
#db
	my ($overwrite, $verbose) = @_;
	my $err = '';
	$verbose = 0 unless $verbose;

	my $dbh = undef();
	my $sth = undef();

	Err: {
		$err = &get_dbh(\$dbh);
		next Err if ($err);

		&ppstr(174, $str[98] ) if ($verbose);

		my %existing_tables = ();
		$sth = $dbh->prepare('SHOW tables');
		$sth->execute();
		if ($sth->rows == 0) {
			#print "No names matched\n\n";
			}
		else {
			my @data = ();
			while (@data = $sth->fetchrow_array()) {
				$existing_tables{$data[0]}++;
				}
			}
		$sth->finish();
		$sth = undef();

		if ($overwrite) {

			my @tables = ($Rules{'sql: table name: realms'}, $Rules{'sql: table name: addresses'});
			table: foreach (@tables) {

				next unless ($existing_tables{$_});

				my $query = "drop table $_";

				unless ($sth = $dbh->prepare($query)) {
					$err .= &pstr(64, $str[45] . ' ' . $dbh->errstr());
					next table;
					}

				if ($sth->execute()) {
					$err .= &pstr(174, &pstr(99, $_ ));
					undef($existing_tables{$_});
					}
				else {
					$err .= &pstr(64, $str[29] . ' ' . $sth->errstr());
					}
				$sth->finish();
				$sth = undef();
				}
			}

		$dbh->disconnect();
		$dbh = undef();

		unless ($existing_tables{$Rules{'sql: table name: realms'}}) {

$err = &db_exec(<<"EOM");

create table $Rules{'sql: table name: realms'} (
	realm_id int auto_increment not null,
	name varchar(255) not null,
	description text,
	file varchar(255),
	is_runtime int,
	basedir varchar(255),
	baseurl varchar(255),
	pagecount int not null,
	primary key (realm_id),
	unique (name)
	)

EOM
			next Err if ($err);
			}

		unless ($existing_tables{$Rules{'sql: table name: addresses'}}) {

$err = &db_exec(<<"EOM");

create table $Rules{'sql: table name: addresses'} (
	myid int auto_increment not null,
	realm_id int not null,
	url varchar(255) not null,
	um varchar(255) not null,
	lastindex int not null,
	lastmodtime int not null,
	dd int not null,
	mm int not null,
	yyyy int not null,
	promote int not null,
	size int not null,
	title text not null,
	ut text,
	description text,
	ud text,
	keywords varchar(255),
	uk varchar(255),
	text mediumtext,
	links text,
	primary key (myid),
	unique (url)
	)

EOM
			next Err if ($err);
			}

$err = &db_exec(<<"EOM");

	create index $Rules{'sql: table name: addresses'}_url_ind on $Rules{'sql: table name: addresses'} (url)

EOM
			if ($err) {
				$err .= &pstr(53, $err );
				}
			next Err if ($err);

		# audit our success:
		my ($addr_count, $realmcount, $log_exists);
		($err, $addr_count, $realmcount, $log_exists) = &check_db_config($verbose);
		next Err if ($err);

		if ($addr_count != 0) {
			$err .= &pstr(64, &pstr(497, $Rules{'sql: table name: addresses'}, $addr_count) );
			}
		if ($realmcount != 0) {
			$err .= &pstr(64, &pstr(497, $Rules{'sql: table name: realms'}, $realmcount) );
			}
		last Err;
		}
	$sth->finish() if ($sth);
	$dbh->disconnect() if ($dbh);
	return $err;
#/db
	}





sub create_sql_log {
#db
	my $dbh = undef();
	my $sth = undef();

	my $err= '';
	Err: {
		$err = &get_dbh( \$dbh );
		next Err if ($err);

		$sth = $dbh->prepare("DROP table $Rules{'sql: table name: logs'}");
		$sth->execute();
		$sth->finish();
		$sth = undef();
		$dbh->disconnect();
		$dbh = undef();

		$err = &db_exec(<<"EOM");

create table $Rules{'sql: table name: logs'} (

	search_id int auto_increment not null,

	visitor_ip varchar(255) not null,
	unix_time int not null,
	human_time datetime not null,
	realm varchar(255) not null,
	terms varchar(255) not null,
	rank int not null,
	documents_found int not null,
	documents_searched int not null,

	primary key (search_id),

	unique (search_id)
	)
EOM
		next Err if ($err);
		}
	$sth->finish() if ($sth);
	$dbh->disconnect() if ($dbh);
	return $err;
#/db
	}





sub migrate_log {
#revcompat 0029
	my $err = '';
	Err: {

		print "<p>$str[103]</p>\n";

		my ($obj, $p_rhandle, $p_whandle) = ();

		$obj = &LockFile_new();
		($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('search.log.txt');
		next Err if ($err);

		my %timecache = ();

		my %Record = ();

		my $i = 1;
		while (defined($_ = readline( $$p_rhandle ))) {

			next if (m!^\r?$!); # skip blank lines
			if (m!^(\w+)\:\t(.*)$!) {
				$Record{$1} = $2;

				if ($1 eq 'Found') {
					foreach (keys %Record) {
						$Record{$_} =~ s!\,|\n|\r|\015|\012! !g;
						$Record{$_} =~ s!\s+! !g;
						$Record{$_} =~ s!^ !!o;
						$Record{$_} =~ s! $!!o;
						}

					my $time = '';
					if ($Record{'Time'} =~ m!^\s*\w+\s+(\w+)\s+(\d+)\s+(\d+)\:(\d+)\:(\d+)\s+(\d+)\s*$!) {
						my ($mon_str, $mday, $hh, $mm, $ss, $yyyy) = (lc($1), $2, $3, $4, $5, $6);
						$time = &timelocal($ss,$mm, $hh, $mday, $mon_str, $yyyy, \%timecache);

						#print "Time is $time - $Record{'Time'} - " . scalar localtime($time) . "<br />\n" if ($i < 100);
						}
					else {
						&ppstr(53, &pstr(104, $Record{'Time'} ));
						}

					my $logline = "$Record{'Host'} ,$time,$Record{'Time'},," . &he($Record{'Terms'}) . ",,$Record{'Found'},,\n";

					print { $$p_whandle } $logline;
					$i++;
					if (($i % 500) == 0) {
						&ppstr(105, $i );
						print "<br />\n";
						}
					%Record = ();
					}
				}
			else {
				print { $$p_whandle } $_;
				$i++;
				if (($i % 500) == 0) { &ppstr(105, $i ); print "<br />\n"; }
				}
			}

		$err = $obj->Merge();
		next Err if ($err);

		last Err;
		}
	continue {
		&ppstr(64,$err);
		}
#/revcompat
	}





sub ui_ViewStats {
	local $_;

	my @sql_field_names = (
		'search_id',
		'visitor_ip',
		'unix_time',
		'human_time',
		'realm',
		'terms',
		'rank',
		'documents_found',
		'documents_searched',
		);

	my @FieldNames = (
		$str[125],
		$str[126],
		$str[127],
		$str[128],
		$str[531],
		$str[130],
		$str[131],
		$str[132],
		$str[133],
		$str[134],
		$str[135],
		$str[136],
		$str[137],
		'Interface language',
		);


	my %rev_FieldNames = ();
	my $i = 0;
	foreach (@FieldNames) {
		$rev_FieldNames{$_} = $i;
		$i++;
		}

	my $dbh = undef();
	my $sth = undef();

	my $err = '';
	Err: {

		# either list or group:
		my $subaction = lc($FORM{'subaction'});


print <<"EOM";

		<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> / <a href="$const{'admin_url'}&amp;Action=ViewLog">$str[106]</a> /

EOM

		if ($subaction =~ m!^(dbm|list|group)$!) {
			my $url = "$const{'admin_url'}&amp;Action=ViewLog";
			foreach ('subaction','ob','orderby','sort','file') {
				next unless (defined($FORM{$_}));
				$url .= "&amp;$_=" . &url_encode($FORM{$_});
				}
			print qq!<a href="$url">View Log</a></b></p>\n!;
			}
		else {
			print "$str[152]</b></p>\n";
			}


		unless ($subaction) {

print <<"EOM";

			<p><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=list">$str[110]</a>

EOM

			if ($const{'mode'} == 3) {
				print '</p>';
				}
			else {


print <<"EOM";

$str[111]</p>

			<ul>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=value&amp;orderby=5">$str[112]</a></li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=value&amp;orderby=9">$str[134]</a></li>
			</ul>
			<ul>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=value&amp;orderby=1">$str[126]</a></li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=key&amp;orderby=7">$str[115]</a></li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=key&amp;orderby=6">$str[131]</a></li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=value&amp;orderby=4">$str[531]</a></li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=value&amp;orderby=13">Interface language</a></li>
			</ul>
			<ul>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=key&amp;orderby=10">$str[135]</a> $str[120]</li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=key&amp;orderby=11">$str[118]</a> $str[121]</li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;ob=key&amp;orderby=12">$str[119]</a> $str[121]</li>
			</ul>

EOM

print <<"EOM" if ($Rules{'use dbm routines'});

<p>Graphs can also be made based on the DBM files:</p>

			<ul>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=dbm&amp;file=dbm_strlog_top">$str[112]</a> (dbm_strlog_top; top $Rules{'logging: display most popular'})</li>
				<li><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=dbm&amp;file=dbm_strlog_all">$str[112]</a> (dbm_strlog_all)</li>
			</ul>


EOM
				}

			print '<hr size="1" />';

			my @settings = ('logging: enable');
			push(@settings, 'logging: display most popular' ) if ($Rules{'use dbm routines'});

			&ui_GeneralRules( $str[106], 'ViewLog', @settings );

			my $csvkb = 0;
			if (-e 'search.log.txt') {
				$csvkb = &FormatNumber( int((1023 + (-s 'search.log.txt')) / 1024), 0, 0, 0, 1, $Rules{'ui: number format'} );
				}
			my $dbmkb = 0;
			my $basefile;
			foreach $basefile ('dbm_strlog_top','dbm_strlog_top') {
				my $ext;
				foreach $ext ('', '.dir', '.pag', '.db') {
					my $file = $basefile . $ext;
					next unless (-e $file);
					$dbmkb += -s $file;
					}
				}
			$dbmkb = &FormatNumber( int((1023 + $dbmkb) / 1024), 0, 0, 0, 1, $Rules{'ui: number format'} );

			my $str = &pstr( 540, 'Logging: Display Most Popular' );

print <<"EOM";

<hr size="1" />

$const{'AdminForm'}
<input type="hidden" name="Action" value="ViewLog" />
<input type="hidden" name="subaction" value="delete" />

$str

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th>$str[430]</th>
	<th>Format</th>
	<th>Log File</th>
	<th>$str[153]</th>
</tr>
<tr>
	<td align="center"><input type="checkbox" name="del:csv" value="1" /></td>
	<td align="center">CSV</td>
	<td>searchdata/search.log.txt</td>
	<td align="right">$csvkb KB</td>
</tr>
<tr>
	<td align="center"><input type="checkbox" name="del:dbm" value="1" /></td>
	<td align="center">DBM</td>
	<td>searchdata/dbm_strlog *</td>
	<td align="right">$dbmkb KB</td>
</tr>
</table>

<p><input type="submit" class="submit" value="$str[525]" /></p>

</form>

EOM


			last Err;
			}

		if ($subaction eq 'delete') {
			my $delcount = 0;
			if ($FORM{'del:csv'}) {
				$err = &WriteFile('search.log.txt','');
				next Err if ($err);
				&ppstr( 174, &pstr( 383, 'search.log.txt' ) );
				$delcount++;
				}
			if ($FORM{'del:dbm'}) {
				if (not $Rules{'use dbm routines'}) {
					&pppstr( 506, $str[539] );
					}
				else {
					eval {
						foreach ('dbm_strlog_top','dbm_strlog_all') {
							my %hash = ();
							dbmopen( %hash, $_, 0666 ) || die &pstr( 43, $_, $! );
							%hash = (); # clear
							dbmclose(%hash);
							&ppstr( 174, &pstr( 383, $_ ) );
							}
						};
					if ($@) {
						&ppstr(53, &pstr(67, &he($@), "$const{'help_file'}1169.html" ) );
						}
					$delcount++;
					}
				}
			unless ($delcount) {
				$err = $str[532];
				next Err;
				}
			last Err;
			}



		my $focus = lc($FORM{'focus'});
		$focus = 'id' unless ($focus);
		# name of a field

		my $query = 0;
		if ($FORM{'orderby'} =~ m!^\d+$!) {
			$query = $FORM{'orderby'};
			}


		#change 0049 - queries on string date-time (3) are internally handled as 2, the Unix datetime
		$query = 2 if ($query == 3);



		my $field_name = $FieldNames[$query];
		my $AsciiSort = not ($query =~ m!^(0|2|6|7|8)$!);

		my %Groups = ();
		my $ptr = 0;


		#DBM-based sorts

		if ($subaction eq 'dbm') {

			unless ($Rules{'use dbm routines'}) {
				$err = $str[539];
				next Err;
				}

			unless (defined($FORM{'file'})) {
				$err = "parameter 'file' missing";
				next Err;
				}
			my $file = $FORM{'file'};
			unless ($file =~ m!^dbm_strlog_(all|top)$!) {
				$err = "file must match ^dbm_strlog_(all|top)\$";
				next Err;
				}

			eval {
				my %str = ();
				dbmopen( %str, $file, 0666 ) || die &pstr( 44, $file, $! );
				my $count = 1;

print "<p>This file '$file' was initialized on " . &FormatDateTime( $str{'++'}, $Rules{'ui: date format'} ) . ".</p>\n" if ($str{'++'});


				my $obkey = (($FORM{'ob'}) and ($FORM{'ob'} eq 'key')) ? 1 : 0;
				my $rev = (($FORM{'sort'}) and ($FORM{'sort'} eq 'rev')) ? 1 : 0;

				my $nsort = $rev ? 'n' : 'rev';

print <<"EOM";

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2"><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=dbm&amp;file=$file&amp;ob=value&amp;sort=$nsort" class="onblue">Frequency</a></th>
	<th><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=dbm&amp;file=$file&amp;ob=key&amp;sort=$nsort" class="onblue">$str[112]</a></th>
</tr>

EOM

				my $max_value = $str{'+++'} || 100;
				my $total = 0;

				my $p_raw = sub {
					my ($name, $value, $p_count) = @_;
					my $b_last = 0;
					if ($name !~ m!^\++$!) {
						$total += $value;
						my $width = 1 + int( 120 * $value / $max_value );
print <<"EOM";

<tr>
	<td align="right"><img src="http://xav.com/i/red.gif" width="$width" height="10" border="1" alt="" /></td>
	<td align="right"><tt>$value</tt></td>
	<td>$name<br /></td>
</tr>

EOM
						$$p_count++;
						if (($file eq 'dbm_strlog_top') and ($$p_count > $Rules{'logging: display most popular'})) {
							$b_last = 1;
							}
						}
					return $b_last;
					};



				if ($obkey) {
					if ($rev) {
						foreach (sort { $b cmp $a } keys %str) {
							last if &{ $p_raw }( $_, $str{$_}, \$count );
							}
						}
					else {
						foreach (sort { $a cmp $b } keys %str) {
							last if &{ $p_raw }( $_, $str{$_}, \$count );
							}
						}
					}
				else {
					if ($rev) {
						foreach (sort { $str{$a} <=> $str{$b} || $b cmp $a } keys %str) {
							last if &{ $p_raw }( $_, $str{$_}, \$count );
							}
						}
					else {
						foreach (sort { $str{$b} <=> $str{$a} || $a cmp $b } keys %str) {
							last if &{ $p_raw }( $_, $str{$_}, \$count );
							}
						}
					}


print <<"EOM";

</table>

<p>Handled $total total records.</p>

EOM

				};
			if ($@) {
				$err = &pstr(67, &he($@), "$const{'help_file'}1169.html" );
				next Err;
				}
			}



		elsif ($Rules{'sql: logfile'}) {
#db
			my ($var, @row) = ();
			$err = &get_dbh( \$dbh );
			next Err if ($err);

			if ($subaction eq 'list') {

				my $sql_order_by = $sql_field_names[ $FORM{'orderby'} ];

				my $query = "SELECT * FROM $Rules{'sql: table name: logs'} ORDER BY $sql_order_by";

				if ($FORM{'sort'}) {
					$query .= " ASC";
					}
				else {
					$query .= " DESC";
					}

				unless ($sth = $dbh->prepare($query)) {
					$err = $str[45] . ' ' . $dbh->errstr();
					next Err;
					}

				unless ($sth->execute()) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}

				my $separ = '';

print <<"EOM";

				<p>$str[122]</p>
				<table border="1" cellspacing="0" cellpadding="3">
				<tr valign="bottom">

EOM
				my $name = ();
				foreach $name ((@FieldNames)[0,1,3..8]) {
					$separ .= "<th>$name</th>\n";
					if (($FORM{'orderby'} eq $rev_FieldNames{$name}) and (not ($FORM{'sort'}))) {
						print qq!<th><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=list&amp;orderby=$rev_FieldNames{$name}&amp;sort=rev" class="onblue">$name</a></th>\n!;
						}
					else {
						print qq!<th><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=list&amp;orderby=$rev_FieldNames{$name}" class="onblue">$name</a></th>!;
						}
					}
				print "</tr>";

				my $matchcount = 0;
				my $i = 0;
				my @data = ();
				while (@data = $sth->fetchrow_array()) {
					$ptr++;

					if ($i % 2) {
						print '<tr>';
						}
					else {
						print '<tr class="g">';
						}

					my @display_terms = @data[0,1,3..8];

					$matchcount += $data[7];
					$display_terms[7] = &FormatNumber( $data[7], 0, 0, 0, 1, $Rules{'ui: number format'} );


					printf( qq!<td align="right">%s</td><td align="right">%s</td><td align="right" nowrap="nowrap">%s</td><td nowrap="nowrap">%s<br /></td><td>%s<br /></td><td align="right">%s<br /></td><td align="right">%s<br /></td><td align="right">%s<br /></td></tr>\n!, @display_terms );

					$i++;

					if (($i % 200) == 0) {
						print "</table><p>";
						&ppstr(105,$i);
						print qq!</p><table border="1" cellspacing="0" cellpadding="3"><tr>$separ</tr>\n!;
						}
					}
				$sth->finish();
				$sth = undef();
				$dbh->disconnect();
				$dbh = undef();

				print '</table>';
				&pppstr(139,$ptr);
				if ($matchcount) {
					&ppstr(138, &FormatNumber( ($matchcount / $ptr), 2, 1, 0, 1, $Rules{'ui: number format'} ) );
					}

				}
			elsif (($subaction eq 'group') and ($FORM{'orderby'} < 8)) {

				my $max_value = 1;

				my $sql_focus_on = $sql_field_names[ $FORM{'orderby'} ];

				my $sql_query = "SELECT count(*), $sql_focus_on FROM $Rules{'sql: table name: logs'} GROUP BY $sql_focus_on";
				unless ($sth = $dbh->prepare($sql_query)) {
					$err = $str[45] . ' ' . $dbh->errstr();
					next Err;
					}
				unless ($sth->execute()) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}
				my @data = ();
				while (@data = $sth->fetchrow_array()) {
					$max_value = $data[0] if ($max_value < $data[0]);
					}
				$sth->finish();
				$sth = undef();

				$sql_query = "SELECT count(*) AS cnt, $sql_focus_on AS focus FROM $Rules{'sql: table name: logs'} GROUP BY $sql_focus_on ORDER BY ";

				if ($FORM{'ob'} eq 'value') {
					$sql_query .= "cnt";
					}
				else {
					$sql_query .= "focus";
					}

				if ($FORM{'sort'}) {
					$sql_query .= " ASC";
					}
				else {
					$sql_query .= " DESC";
					}

				unless ($sth = $dbh->prepare($sql_query)) {
					$err = $str[45] . ' ' . $dbh->errstr();
					next Err;
					}

				unless ($sth->execute()) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}

print <<"EOM";

				<p>$str[122]</p>
				<table border="1" cellspacing="0" cellpadding="3">
				<tr valign="bottom">

EOM

				print qq!<th colspan="2">\n!;
				print "<a href=\"$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;orderby=$FORM{'orderby'}&amp;ob=value";

				if (($FORM{'ob'} eq 'value') and (!$FORM{'sort'})) {
					print "&amp;sort=rev";
					}

				print "\" class=\"onblue\">$str[140]</a></th><th>";

				print "<a href=\"$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;orderby=$FORM{'orderby'}&amp;ob=key";

				if (($FORM{'ob'} eq 'key') and (!$FORM{'sort'})) {
					print "&amp;sort=rev";
					}
				print "\" class=\"onblue\">$field_name</a></th></tr>\n";


				my $i = 0;
				@data = ();
				my ($value, $name) = ();
				while (($value, $name) = $sth->fetchrow_array()) {

					if ($i % 2) {
						print '<tr valign="top">';
						}
					else {
						print '<tr valign="top" class="g">';
						}

					my $width = 1 + int(120 * $value / $max_value);
					print qq!<td align="right"><img src="http://xav.com/i/red.gif" height="10" width="$width" alt="" border="1" /></td><td align="right">$value</td><td align="right">$name</td></tr>\n!;
					$i++;
					if (($i % 200) == 0) {
						print "</table>";
						&pppstr(105,$i);
						print qq!<table border="1" cellspacing="0" cellpadding="3">\n!;
						}
					}
				$sth->finish();
				$sth = undef();
				$dbh->disconnect();
				$dbh = undef();

				print '</table>';

				}
			elsif ($subaction eq 'group') {

				my $name_align_right = 0;

				my $sql_query = '';
				if ($query == 9) {
					$sql_query = "SELECT terms AS focus, count(*) AS cnt FROM $Rules{'sql: table name: logs'} GROUP BY terms";
					}
				else {
					$sql_query = "SELECT unix_time FROM $Rules{'sql: table name: logs'}";
					}

				unless ($sth = $dbh->prepare( $sql_query )) {
					$err = $str[45] . ' ' . $dbh->errstr();
					next Err;
					}

				unless ($sth->execute()) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}

				if ($query == 9) {
					my $i = 0;
					my ($lterms, $freq) = ('', 0);
					while (($lterms, $freq) = $sth->fetchrow_array()) {
						foreach (split(m!\s+!, $lterms)) {
							$Groups{$_} += $freq;
							}
						}
					}
				else {
					# time ones:
					my $unixtime = 0;
					while (($unixtime) = $sth->fetchrow_array()) {
						if ($query == 10) {
							# linear day
							my ($mon, $day, $year) = (localtime($unixtime))[4,3,5];
							$year += 1900;
							$mon++;
							$mon = "0$mon" if (length($mon) == 1);
							$day = "0$day" if (length($day) == 1);
							$Groups{"$year/$mon/$day"}++;
							}
						elsif ($query == 11) {
							# hour of day
							my $hour = (localtime($unixtime))[2];
							$Groups{$hour}++;
							}
						elsif ($query == 12) {
							# day of week
							my $wday = (localtime($unixtime))[6];
							$Groups{$wday}++;
							}
						}

					if ($query == 10) {
						$AsciiSort = 1;
						}
					elsif ($query == 11) {
						$AsciiSort = 0;
						$name_align_right = 1;
						}
					elsif ($query == 12) {
						$AsciiSort = 0;
						$name_align_right = 0;
						}

					}
				$sth->finish();
				$sth = undef();
				$dbh->disconnect();
				$dbh = undef();

print <<"EOM";

				<p>$str[122]</p>
				<table border="1" cellspacing="0" cellpadding="3">
				<tr valign="bottom">

EOM
				print qq!<th colspan="2">\n!;
				print qq!<a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;orderby=$FORM{'orderby'}&amp;ob=value!;

				if (($FORM{'ob'} eq 'value') and (not $FORM{'sort'})) {
					print "&amp;sort=rev";
					}

				print qq!" class="onblue">$str[140]</a></th><th>!;

				print "<a href=\"$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;orderby=$FORM{'orderby'}&amp;ob=key";

				if (($FORM{'ob'} eq 'key') and (!$FORM{'sort'})) {
					print "&amp;sort=rev";
					}
				print "\" class=\"onblue\">$field_name</a></th></tr>\n";

				my $by_value = (($FORM{'ob'}) and ($FORM{'ob'} eq 'value'));
				my $ascending = (($FORM{'sort'}) and ($FORM{'sort'} eq 'rev'));

				$err = &PrintOrderedHash( \%Groups, $by_value, $AsciiSort, $ascending, $query, $name_align_right );
				next Err if ($err);

				print '</table>';

				}
#/db
			}
		else {

			unless (-e 'search.log.txt') {
				$err = &pstr(155,'search.log.txt');
				next Err;
				}

			# Migrate log file format if necessary:

			if (open(LOGFILE, "<search.log.txt" )) {
				binmode(LOGFILE);
				my $buffer = '';
				read(LOGFILE, $buffer, 1024);
				close(LOGFILE);

				if ($buffer =~ m!Time:\t.*?Host:\t.*?Terms:\t.*?Found:\t!is) {

					# yep... we have us a legacy log - convert it real quick...

					&migrate_log('search.log.txt');
					}
				}

			my (@Newtable, @table, @SortField) = ();

			if ($subaction eq 'list') {

				my $focus_term = '';

				unless (open( LOGFILE, "<search.log.txt" )) {
					$err = &pstr(44,'search.log.txt',$!);
					next Err;
					}
				binmode(LOGFILE);
				while (defined($_ = <LOGFILE>)) {
					$ptr++;
					my $full_record = "$ptr,$_";
					push(@table, $full_record);
					$focus_term = (split(m!\,!, $full_record))[$query];
					push(@SortField, $focus_term);
					}
				close(LOGFILE);

				if ($AsciiSort) {
					@Newtable = @table[sort{ $SortField[$a] cmp $SortField[$b] } 0..$#table];
					}
				else {
					@Newtable = @table[sort{ $SortField[$b] <=> $SortField[$a] } 0..$#table];
					}

				if (($FORM{'sort'}) and ($FORM{'sort'} eq 'rev')) {
					@Newtable = reverse @Newtable;
					}

print <<"EOM";

				<p>$str[122]</p>
				<table border="1" cellspacing="0" cellpadding="3">
				<tr valign="bottom">

EOM
				my $separ = '';
				my $name = ();
				foreach $name ((@FieldNames)[0,1,3..8]) {
					$separ .= "<th>$name</th>\n";
					if (($FORM{'orderby'} eq $rev_FieldNames{$name}) and (not ($FORM{'sort'}))) {
						print "<th><a href=\"$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=list&amp;orderby=$rev_FieldNames{$name}&amp;sort=rev\" class=\"onblue\">$name</a></th>";
						}
					else {
						print "<th><a href=\"$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=list&amp;orderby=$rev_FieldNames{$name}\" class=\"onblue\">$name</a></th>";
						}
					}
				print "</tr>\n";

				my $matchcount = 0;
				my $i = 0;
				my @Fields = ();
				foreach (@Newtable) {
					@Fields = split(m!,!);
					if ($i % 2) {
						print '<tr>';
						}
					else {
						print '<tr class="g">';
						}

					my @diplay_fields = @Fields[0,1,3..8];


					$matchcount += $Fields[7];
					$diplay_fields[7] = &FormatNumber( $diplay_fields[7], 0, 0, 0, 1, $Rules{'ui: number format'} );


					printf( qq!<td align="right">%s</td><td align="right">%s</td><td align="right" nowrap="nowrap">%s</td><td nowrap="nowrap">%s<br /></td><td>%s<br /></td><td align="right">%s<br /></td><td align="right">%s<br /></td><td align="right">%s<br /></td></tr>\n!, @diplay_fields );

					$i++;
					if (($i % 200) == 0) {
						print "</table>";
						&pppstr(105,$i);
						print qq!<table border="1" cellspacing="0" cellpadding="3"><tr>$separ</tr>\n!;
						}
					}

				print '</table>';
				&pppstr(139, $ptr );
				if ($matchcount) {
					&pppstr(138, &FormatNumber( ($matchcount / $ptr), 2, 1, 0, 1, $Rules{'ui: number format'} ) );
					}

				}

			elsif ($subaction eq 'group') {

				my $name_align_right = ($AsciiSort) ? 0 : 1;

				unless (open( LOGFILE, "<search.log.txt" )) {
					$err = &pstr(44,'search.log.txt',$!);
					next Err;
					}
				binmode(LOGFILE);
				my $focus_term = '';
				while (defined($_ = <LOGFILE>)) {
					$ptr++;

					my $full_record = "$ptr,$_";


					if (($query > 9) and ($query < 13)) {
						# time-based grouping
						my $unixtime = (split(m!\,!, $full_record))[2];
						if ($query == 10) {
							# linear day

							my ($mon, $day, $year) = (localtime($unixtime))[4,3,5];
							$year += 1900;
							$mon++;
							$mon = "0$mon" if (length($mon) == 1);
							$day = "0$day" if (length($day) == 1);
							$Groups{"$year/$mon/$day"}++;
							}
						elsif ($query == 11) {
							# hour of day
							my $hour = (localtime($unixtime))[2];
							$Groups{$hour}++;
							}
						elsif ($query == 12) {
							# day of week
							my $wday = (localtime($unixtime))[6];
							$Groups{$wday}++;
							}
						next;
						}

					$focus_term = (split(m!\,!, $full_record))[$query];
					if ($query == 9) {
						my $Terms = (split(m!\,!, $full_record))[5];
						foreach (split(m!\s+!, lc($Terms))) {
							$Groups{$_}++;
							}
						}
					elsif ($query == 13) {
						my $interface_lang = (split(m!\,!, $full_record))[9];
						$interface_lang =~ s!\r|\n!!sg;
						$Groups{$interface_lang}++;
						}
					else {
						$Groups{lc($focus_term)}++;
						}
					}
				close(LOGFILE);

				if (($query > 9) and ($query < 13)) {
					if ($query == 10) {
						$AsciiSort = 1;
						}
					elsif ($query == 11) {
						$AsciiSort = 0;
						$name_align_right = 1;
						}
					elsif ($query == 12) {
						$AsciiSort = 0;
						$name_align_right = 0;
						}
					}


print <<"EOM";

				<p>$str[122]</p>
				<table border="1" cellspacing="0" cellpadding="3">
				<tr valign="bottom">

EOM

				print qq!<th colspan="2"><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;orderby=$FORM{'orderby'}&amp;ob=value!;

				if (($FORM{'ob'} eq 'value') and (!$FORM{'sort'})) {
					print '&amp;sort=rev';
					}

				print qq!" class="onblue">$str[140]</a></th><th><a href="$const{'admin_url'}&amp;Action=ViewLog&amp;subaction=group&amp;orderby=$FORM{'orderby'}&amp;ob=key!;

				if (($FORM{'ob'} eq 'key') and (!$FORM{'sort'})) {
					print "&amp;sort=rev";
					}
				print qq!" class="onblue">$FieldNames[$query]</a></th></tr>\n!;


				my $by_value = (($FORM{'ob'}) and ($FORM{'ob'} eq 'value'));
				my $ascending = (($FORM{'sort'}) and ($FORM{'sort'} eq 'rev'));

				$err = &PrintOrderedHash( \%Groups, $by_value, $AsciiSort, $ascending, $query, $name_align_right );
				next Err if ($err);

				print '</table>';
				&pppstr(139, $ptr );
				}
			}
		last Err;
		}
	continue {
		&ppstr(64,$err);
		}
	$sth->finish() if ($sth);
	$dbh->disconnect() if ($dbh);
	}





sub PrintOrderedHash {
	my ($p_hash, $by_value, $ascii_sort, $ascending, $date_map, $name_align_right) = @_;
	my $err = '';

	my $max_value = 1;
	my ($name, $value) = ();
	while (($name, $value) = each %$p_hash) {
		$max_value = $value if ($value > $max_value);
		}


	my $template1 = '<tr><td align="right"><img src="http://xav.com/i/red.gif" height="10" width="$width" alt="" border="1" /></td><td align="right">&nbsp;$value&nbsp;</td><td>$name<br /></td></tr>\n';
	if ($name_align_right) {
		$template1 = '<tr><td align="right"><img src="http://xav.com/i/red.gif" height="10" width="$width" alt="" border="1" /></td><td align="right">&nbsp;$value&nbsp;</td><td align="right">$name<br /></td></tr>\n';
		}
	my $template2 = '<tr class="g"><td align="right"><img src="http://xav.com/i/red.gif" height="10" width="$width" alt="" border="1" /></td><td align="right">&nbsp;$value&nbsp;</td><td>$name<br /></td></tr>\n';
	if ($name_align_right) {
		$template2 = '<tr class="g"><td align="right"><img src="http://xav.com/i/red.gif" height="10" width="$width" alt="" border="1" /></td><td align="right">&nbsp;$value&nbsp;</td><td align="right">$name<br /></td></tr>\n';
		}

	my $descriptor = '';
	if ($ascending) {
		$descriptor .= 'reverse ';
		}

	my $comp_op = "<=>";
	if ($ascii_sort) {
		$comp_op = "cmp";
		}

	if ($by_value) {
		$descriptor .= 'sort {$$p_hash{$b} <=> $$p_hash{$a} || $a ' . $comp_op . ' $b} keys %$p_hash';
		}
	else {
		$descriptor .= 'sort {$a ' . $comp_op . ' $b} keys %$p_hash';
		}

	# Initialize all fields for the cyclic date hashes:
	if ($date_map == 12) {
		foreach (0..6) {
			$$p_hash{$_} = 0 unless ($$p_hash{$_});
			}
		}
	elsif ($date_map == 11) {
		foreach (0..23) {
			$$p_hash{$_} = 0 unless ($$p_hash{$_});
			}
		}

	my @Weekdays = (
		$str[25],
		$str[24],
		$str[28],
		$str[7],
		$str[6],
		$str[5],
		$str[66],
		);


	my @HourNames = ('midnight', '1:00 AM', '2:00 AM', '3:00 AM', '4:00 AM', '5:00 AM', '6:00 AM', '7:00 AM', '8:00 AM', '9:00 AM', '10:00 AM', '11:00 AM', 'noon', '1:00 PM', '2:00 PM', '3:00 PM', '4:00 PM', '5:00 PM', '6:00 PM', '7:00 PM', '8:00 PM', '9:00 PM', '10:00 PM', '11:00 PM');

	if ($date_map !~ m!^\d+!) {
		$date_map = 0;
		}

	my $code = <<"EOM";

my \$i = 0;
foreach ($descriptor) {
	my (\$name, \$value) = (\$_, \$\$p_hash{\$_});

	if (\$date_map == 12) {
		\$name = \$Weekdays[\$name];
		}
	elsif (\$date_map == 11) {
		\$name = \$HourNames[\$name];
		}

	my \$width = 1 + int((120 * \$value) / \$max_value);
	if (\$i % 2) {
		print qq!$template1!;
		}
	else {
		print qq!$template2!;
		}
	\$i++;
	}

EOM
	eval $code;
	die $@ if $@;
	return $err;
	}



sub is_valid_filename {
	my ($file) = @_;
	my $err = '';
	Err: {

		# make sure it only contains \w characters and '.'
		my $filechars = $file;
		$filechars =~ s!\w!!g; # strip all alphanumerics and _
		$filechars =~ s!\.!!o; # strip up to one '.'
		if ($filechars) { # uh-oh - other characters remain
			$err = &pstr(54, &he($file), 'invalid characters' );
			next Err;
			}
		}
	return $err;
	}





sub delete_index_file {
	my ($file) = @_;
	my $hfile = &he($file);
	my $err = '';
	Err: {

		$err = &is_valid_filename($file);
		next Err if ($err);

		# Delete the file and any associated files, if they exist. Continue on failure.

		&untaintme(\$file);

		local $_;
		foreach ('', '.working_copy', '.exclusive_lock_request', '.need_approval', '.pagecount', '.temp_file_list.txt') {
			next unless (-e "$file$_");
			unless (unlink("$file$_")) {
				&ppstr(64, &pstr(54, "$hfile$_", $! ) );
				}
			else {
				&ppstr(174, &pstr(383, "$hfile$_" ) );
				}
			}
		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}





sub ui_ManageRealms {
	my $err = '';
	Err: {

		my $is_update = 0;
		if ($FORM{'is_update'}) {
			$is_update = 1;
			}

		my ($file, $base_dir, $base_url, $limit_pattern) = ();

		# so... what's the plan?

		my $subaction = '';
		if ($FORM{'Delete'}) {
			$subaction = 'DeleteRealm';
			}
		elsif ($FORM{'subaction'}) {
			$subaction = $FORM{'subaction'};
			}


		my $Name = '';

		if (($subaction eq 'Edit') and (not $FORM{'Write'}) and (not defined($FORM{'is_update'}))) {

			# We need to load defaults:

			$is_update = 1;

			$FORM{'is_update'} = 1;
			$Name = $FORM{'Realm'};

			$FORM{'orig_name'} = $Name;

			my $p_realm_data = ();
			($err, $p_realm_data) = $realms->hashref( $Name );
			next Err if ($err);

			($file, $base_dir, $base_url) = ($$p_realm_data{'file'}, $$p_realm_data{'base_dir'}, $$p_realm_data{'base_url'});

			$FORM{'is_runtime'} = $$p_realm_data{'is_runtime'};
			$FORM{'type'} = $$p_realm_data{'type'};

			if ($$p_realm_data{'is_filefed'}) {
				$FORM{'is_filefed'} = 1;
				$FORM{'start_url'} = $$p_realm_data{'base_url'};
				}

			if ($$p_realm_data{'type'} > 3) {
				$FORM{'is_local'} = 1;
				}
			if ($$p_realm_data{'type'} > 2) {
				$FORM{'is_website'} = 1;
				}
			$limit_pattern = $$p_realm_data{'limit_pattern'};
			}


		if (($subaction eq 'Create') and (not defined($FORM{'is_update'}))) {

			$FORM{'is_update'} = 0;
			my ($temp_err,$clean, $host, $port) = &uri_parse(&get_absolute_url());
			if (not $temp_err) {
				$base_url = 'http://' . $host . (($port == 80) ? '' : ":$port");
				}

			}

		if ($subaction eq 'Create') {
			# What is my local path?
			$base_dir = $base_dir || &api_get_webroot(0);
			}



		# Admin banner:
		print "<p><b><a href=\"$const{'admin_url'}\" target=\"_top\">$str[96]</a> / <a href=\"$const{'admin_url'}&amp;Action=ManageRealms\">$str[520]</a> / ";

		if ($subaction eq 'DeleteRealm') {
			print $str[430];
			}
		elsif ($subaction eq 'Create') {
			print qq!<a href="$const{'admin_url'}&amp;Action=ManageRealms&amp;subaction=Create">$str[93]</a>!;
			}
		elsif ($subaction eq 'Edit') {
			print $str[368];
			}
		else {
			print $str[152];
			}
		print "</b></p>\n";

		if ($subaction eq 'DeleteRealm') {

			my $p_realm_data = ();
			($err, $p_realm_data) = $realms->hashref($FORM{'Delete'} );
			next Err if ($err);

			my $realm_id = $$p_realm_data{'realm_id'};

			my $realm_name = $$p_realm_data{'name'};#keep - we won't be able to query p_realm_data later!

			my $index_file = $$p_realm_data{'file'};

			$realms->remove( $$p_realm_data{'name'}, 1 );
			$err = $realms->save_realm_data();
			next Err if ($err);

			# Deal with the remaining data:

			if ($Rules{'sql: enable'}) {
				$err = &db_exec("DELETE FROM $Rules{'sql: table name: addresses'} WHERE realm_id = $realm_id");
				next Err if ($err);
				&ppstr(174, $str[175] );
				}
			&ppstr(174, $str[177] );

			my $delcount = 0;
			($err, $delcount) = &DeleteFromPending( $realm_name );
			next Err if ($err);

			&ppstr(174, &pstr(178,$delcount,'search.pending.txt'));

			# Deal with file data:

			if ($Rules{'delete index file with realm'}) {
				&delete_index_file( $index_file );
				}
			else {

				if (($index_file) and (-e $index_file)) {
					&pppstr(176, $index_file, int((1023 + (-s $index_file))/1024) );


# is this a valid file name, according to our check in DelFile? only offer to delete the file if the check will pass:

					# make sure it only contains \w characters and '.'
					my $filechars = $index_file;
					$filechars =~ s!\w!!g; # strip all alphanumerics and _
					$filechars =~ s!\.!!o; # strip up to one '.'

					if ($filechars) { # uh-oh - other characters remain

						# no offer to delete

						}
					else {


print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="ManageRealms" />
<input type="hidden" name="subaction" value="DelFile" />
<input type="hidden" name="File" value="$index_file" />

<blockquote>
	<p><input type="submit" class="submit" value="$str[382]" /></p>
	<p><input type="checkbox" name="ad" value="1" /> $str[516]</p>
</blockquote>
</form>

EOM
						}
					}



				}

			last Err;
			}
		elsif ($subaction eq 'DelFile') {
			&delete_index_file( $FORM{'File'} );
			if ($FORM{'ad'}) {
				$err = &WriteRule('delete index file with realm',1);
				next Err if ($err);
				&ppstr(174,&pstr(404,'delete index file with realm',1));
				}
			last Err;
			}
		elsif (($subaction eq 'Create') or ($subaction eq 'Edit')) {

			if ($const{'mode'} == 3) { # freeware
				if ($subaction eq 'Create') {
					if ($realms->realm_count('all')) {
						$err = "only one realm is allowed in Freeware mode";
						next Err;
						}
					}
				}



			my ($defname, $deffile) = $realms->get_default_name();
			unless ($file) {
				$file = $deffile;
				}
			unless ($Name) {
				$Name = $defname;
				}


			unless ($FORM{'type'}) {
				# default realm type:
				$FORM{'type'} = $Rules{'use socket routines'} ? 3 : 4;
				}

			$base_url = 'http://' unless ($base_url);
			$base_url = 'http://' if ($FORM{'type'} == 6);

			my %defaults = (
				'type' => $FORM{'type'},
				'name' => $Name,
				'is_update' => $FORM{'is_update'},
				'is_website' => 0,
				'is_filefed' => 0,
				'is_local'  => 0,
				'is_runtime' => 0,
				'file'    => $file,

				'base_url2' => $base_url,
				'base_url3' => $base_url,
				'base_url4' => $base_url,
				'base_url5' => $base_url,

				'base_dir4' => $base_dir,
				'base_dir5' => $base_dir,
				'limit_pattern' => $limit_pattern,
				);

			my $table_header = $is_update ? $str[368] : $str[93];
			my $submit_button = $is_update ? $str[362] : $str[93];

			my $h_orig_name = &he( $FORM{'orig_name'} );


			my $b_allow_filtered_realms = (($Rules{'show advanced commands'}) or ($defaults{'type'} == 6));


unless ($FORM{'Write'}) {


			# prevent people from switching to/from runtime type of realm
			my $b_only_runtime = 0;
			my $b_no_runtime = 0;
			if ($is_update) {
				if ($FORM{'type'} == 5) {
					$b_only_runtime = 1;
					}
				else {
					$b_no_runtime = 1;
					}

				if (($FORM{'type'} != 4) and ($FORM{'type'} != 5) and (not $Rules{'use socket routines'})) {
					# special case -- user has disabled sockets, but they are editing an existing realm that
					# depends on sockets.  Make sure that all realm types are present
					$Rules{'use socket routines'} = 1;
					}

				}





print &SetDefaults(<<"EOM", \%defaults);

$const{'AdminForm'}
<input type="hidden" name="is_update" value="$is_update" />
<input type="hidden" name="Action" value="ManageRealms" />
<input type="hidden" name="subaction" value="$FORM{'subaction'}" />
<input type="hidden" name="Write" value="1" />
<input type="hidden" name="orig_name" value="$h_orig_name" />

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$table_header</th>
</tr>
<tr class="fdtan">
	<td align="right" width="120"><b>$str[428]:</b></td>
	<td><tt><input name="name" /></tt></td>
</tr>
<tr class="fdtan">
	<td align="right" width="120"><b>$str[369]:</b></td>
	<td><tt><input name="file" /></tt></td>
</tr>
</table>

<p>$str[367]</p>

<table border="1" cellpadding="4" cellspacing="1" width="50%">

EOM

# open realms:
print &SetDefaults(<<"EOM", \%defaults) if (($const{'mode'} != 3) and (not $b_only_runtime) and ($Rules{'use socket routines'}));

<tr>
	<th colspan="3" align="left"><label for="type_1">$str[431]</label></th>
</tr>
<tr class="fdtan" valign="top">
	<td><input type="radio" name="type" value="1" id="type_1" /></td>
	<td colspan="2">$str[475]</td>
</tr>

EOM

# filtered realms:
print &SetDefaults(<<"EOM", \%defaults) if (($const{'mode'} != 3) and ($b_allow_filtered_realms) and (not $b_only_runtime) and ($Rules{'use socket routines'}));

<tr>
	<th colspan="3" align="left"><label for="type_6">$str[268]</label></th>
</tr>
<tr class="fdtan" valign="top">
	<td><input type="radio" name="type" value="6" id="type_6" /></td>
	<td colspan="2">$str[527]</td>
</tr>


EOM

my $limit_pattern_visible = <<"EOM";

<tr class="fdtan">
	<td align="right" width="120"><b>Pattern:</b></td>
	<td><tt><input name="limit_pattern" size="60" /></tt></td>
</tr>

EOM
my $limit_pattern_hidden = qq!<input type="hidden" name="limit_pattern" />!;
my $website_realm_rows = 2;
if ($Rules{'show advanced commands'}) {
	$limit_pattern_hidden = '';
	$website_realm_rows++;
	}
else {
	$limit_pattern_visible = '';
	}

# file-fed realms and website realms (crawler):
print &SetDefaults(<<"EOM", \%defaults) if ((not $b_only_runtime) and ($Rules{'use socket routines'}));

<tr>
	<th colspan="3" align="left"><label for="type_2">$str[489]</label></th>
</tr>
<tr class="fdtan" valign="top">
	<td rowspan="2"><input type="radio" name="type" value="2" id="type_2" /></td>
	<td colspan="2">$str[208]</td>
</tr>
<tr class="fdtan">
	<td align="right" width="120" nowrap="nowrap"><b>$str[166]:</b></td>
	<td><tt><input name="base_url2" size="60" /></tt></td>
</tr>

<tr>
	<th colspan="3" align="left"><label for="type_3">$str[365]</label></th>
</tr>
<tr class="fdtan" valign="top">
	<td rowspan="$website_realm_rows"><input type="radio" name="type" value="3" id="type_3" /></td>
	<td colspan="2">$str[471]</td>
</tr>
<tr class="fdtan">
	<td align="right" width="120"><b>$str[166]:</b></td>
	<td><tt><input name="base_url3" size="60" />$limit_pattern_hidden</tt></td>
</tr>
$limit_pattern_visible

EOM

# website realms (file system):
print &SetDefaults(<<"EOM", \%defaults) if (not $b_only_runtime);

<tr>
	<th colspan="3" align="left"><label for="type_4">$str[366]</label></th>
</tr>
<tr class="fdtan" valign="top">
	<td rowspan="3"><input type="radio" name="type" value="4" id="type_4" /></td>
	<td colspan="2">$str[471]</td>
</tr>
<tr class="fdtan">
	<td align="right" width="120"><b>$str[166]:</b></td>
	<td><tt><input name="base_url4" size="60" /></tt></td>
</tr>
<tr class="fdtan">
	<td align="right" width="120"><b>$str[399]:</b></td>
	<td><tt><input name="base_dir4" size="60" /></tt></td>
</tr>

EOM

# runtime realms:
print &SetDefaults(<<"EOM", \%defaults) unless ($b_no_runtime);

<tr>
	<th colspan="3" align="left"><label for="type_5">$str[513]</label></th>
</tr>
<tr class="fdtan" valign="top">
	<td rowspan="3"><input type="radio" name="type" value="5" id="type_5" /></td>
	<td colspan="2">$str[212]</td>
</tr>
<tr class="fdtan">
	<td align="right" width="120"><b>$str[166]:</b></td>
	<td><tt><input name="base_url5" size="60" /></tt></td>
</tr>
<tr class="fdtan">
	<td align="right" width="120"><b>$str[399]:</b></td>
	<td><tt><input name="base_dir5" size="60" /></tt></td>
</tr>

EOM
print &SetDefaults(<<"EOM", \%defaults);

</table>

<blockquote>
	<p><input type="submit" class="submit" value="$submit_button" /></p>
</blockquote>

</form>

EOM
				}

			if ($FORM{'Write'}) {

				my ($base_url, $base_dir) = ('', '');

				my $Name = $FORM{'name'};
				if ($Name =~ m!^(all|include-by-name)$!i) {
					$err = &pstr(441,$Name);
					next Err;
					}

				my $File = $FORM{'file'};

				my $type = $FORM{'type'};
				my ($is_runtime, $is_filefed) = (0, 0);

				if ($type == 6) {
					$base_url = 'http://filtered:1/';
					}
				elsif ($type == 5) {
					$is_runtime = 1;
					$File = 'RUNTIME';
					$base_url = $FORM{'base_url5'};
					$base_dir = $FORM{'base_dir5'};
					}
				elsif ($type == 4) {
					# oka
					$base_url = $FORM{'base_url4'};
					$base_dir = $FORM{'base_dir4'};
					}
				elsif ($type == 3) {
					$base_url = $FORM{'base_url3'};
					}
				elsif ($type == 2) {
					$is_filefed = 1;
					$base_url = $FORM{'base_url2'};
					}
				elsif ($type == 1) {
					# cool
					}
				else {
					$err = "invalid type - $type";
					next Err;
					}

				if (($type > 3) and ($const{'mode'} == 0)) {
					$err = $str[435];
					next Err;
					}

				#changed 0035 - this occurs when somebody chooses "Edit" a RUNTIME realm and they toggle the
				# radio buttons to change type, but don't type in a new filename. Also if somebody
				# enters the otherwise reserved word "runtime" we should point them in a different direction
				if ((uc($File) eq 'RUNTIME') and ($type != 5)) {
					my ($defname, $deffile) = $realms->get_default_name();
					$File = $deffile;
					}


				unless ($Name) {
					$err = &pstr(21, $str[428] );
					next Err;
					}
				unless ($File) {
					$err = &pstr(21, $str[369] );
					next Err;
					}

				# use all forward slashes:
				$base_dir =~ s!\\!/!g;

				if ($type != 1) {
					($err, $base_url) = &uri_parse($base_url);
					next Err if ($err);
					}

				# do not allow delimiters within the values:
				for ($Name, $File, $base_dir, $base_url) {
					if (m!(\r|\n|\||\012|\015)!) {
						my $bad = &he($1);
						$err = &pstr(75,&he($_),$bad);
						next Err;
						}
					}

				#0054: -T compat
				if ($File =~ m!\.\.!) {
					$err = "realm file name cannot contain '..' substring";
					next Err;
					}
				&untaintme( \$File );
				&untaintme( \$base_dir );

				if (($type == 4) or ($type == 5)) {
					unless (opendir(DIR, $base_dir)) {
						$err = &pstr(91, &he($base_dir), $! );
						next Err;
						}
					closedir(DIR);
					}

				unless ($is_runtime) {

					# don't bother with LockFile here, because index file is not yet being hammered by multiple processes:
					if (open( FILE, ">>$File" )) {
						close(FILE);
						chmod($private{'file_mask'},$File);
						}
					else {
						$err = &pstr(42, &he($File), $! );
						next Err;
						}
					}

				if ($FORM{'limit_pattern'}) {
					$err = &check_regex($FORM{'limit_pattern'});
					next Err if ($err);
					}


				my $realm_id = 0;
				my $page_count = 0;

				my $p_realm_data = ();

				# Is this really an update operation? If so, retain the 'realm_id' - that's kinda important:
				if ($is_update) {
					($err, $p_realm_data) = $realms->hashref( $FORM{'orig_name'} );
					unless ($err) {
						$realm_id = $$p_realm_data{'realm_id'};
						$page_count = $$p_realm_data{'pagecount'};
						}
					else {
						$err = ''; # clear
						}
					}

				if ($FORM{'orig_name'}) {
					$realms->remove( $FORM{'orig_name'}, 0 );
					}

				$realms->remove( $Name, 0 );
				$realms->add( $realm_id, $Name, $Rules{'sql: enable'}, $File, $is_runtime, $base_dir, $base_url, '', $page_count, $is_filefed, $type, ($FORM{'limit_pattern'} || '') );
				$err = $realms->save_realm_data();
				next Err if ($err);

				($err, $p_realm_data) = $realms->hashref($Name);
				next Err if ($err);

				#changed 0050 update realm-specific filter rules on a rename op:
				if (($is_update) and ($FORM{'orig_name'} ne $Name)) {
					my $url_orig = &url_encode($FORM{'orig_name'});
					my $is_changed = 0;
					my $fr = &fdse_filter_rules_new();
					my $p_fr = ();
					foreach $p_fr ($fr->list_filter_rules()) {
						next unless ($$p_fr{'apply_to'} == 3); # only realm-specific rules
						$is_changed += scalar ($$p_fr{'apply_to_str'} =~ s!(^|,)$url_orig($|,)!$1$$p_realm_data{'url_name'}$2!g);
						}
					if ($is_changed) {
						$err = $fr->frwrite();
						next Err if ($err);
						}
					}

				if ($is_update) {
					&ppstr(174, $str[114] );
					}
				else {
					&ppstr(174, &pstr(372, &he($Name) ) );
					}


				Pending: {

				# update the pending pages file because we may have just added or removed a non-empty index file, and we need to
				# sync the contents of pending.txt with that data

				# we may have renamed a realm, and we need to sync the realm name


					last Pending if ($File eq 'RUNTIME');

					my @NewRecords = ();
					my $new_record_count = 0;

					unless ($Rules{'sql: enable'}) {
						my $url_realm = &url_encode( $Name );
						my $Time = $private{'script_start_time'};
						last Pending unless (open( FILE, "<$File" ));
						binmode(FILE);
						while (defined($_ = <FILE>)) {
							next unless (m! u= (.*?) t=!);
							push(@NewRecords, "$1 $url_realm $Time\n");
							}
						close(FILE);
						$new_record_count = 1 + $#NewRecords;
						if ($new_record_count) {
							&pppstr(373, $new_record_count, $File );
							}
						}

					my $obj = &LockFile_new(
						'create_if_needed' => 1,
						);

					my ($p_rhandle, $p_whandle);

					($err, $p_rhandle) = $obj->Read('search.pending.txt');
					next Err if ($err);

					my @OldRecords = ();

					# This is horribly innefficient code and must be optimized

					# Read in all of the entries except those tied to name or orig_name
					my $exclude = '';
					if (($FORM{'orig_name'}) and ($FORM{'orig_name'} ne $Name)) {
						$exclude = '(' . quotemeta( $FORM{'orig_name'} ) . '|' . quotemeta( $Name ) . ')';
						}
					else {
						$exclude = quotemeta($Name);
						}
					while (defined($_ = readline($$p_rhandle))) {
						next if (m! $exclude !);
						push(@OldRecords, $_);
						}
					$err = $obj->Close();
					next Err if ($err);

					undef($obj);

					$obj = &LockFile_new(
						'create_if_needed' => 1,
						);
					($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('search.pending.txt');
					next Err if ($err);

					my ($Current, $Previous) = ('', '');
					my ($CurrentNum, $PreviousNum) = (0, 0);
					foreach (sort (@OldRecords, @NewRecords)) {
						next unless m!^(.*?) (.*?) (\d+)$!;
						$Current = "$1 $2";
						$CurrentNum = $3;
						if ($Current ne $Previous) {
							my $data = "$Current ";
							$data .= (($CurrentNum > $PreviousNum) ? $CurrentNum : $PreviousNum);
							$data .= "\n";
							print { $$p_whandle } $data;
							}
						$Previous = $Current;
						$PreviousNum = $CurrentNum;
						}
					$err = $obj->Merge();
					next Err if ($err);

					$realms->setpagecount($Name, $new_record_count, 1);
					if ($new_record_count) {
						&ppstr(174, &pstr(179, $new_record_count,'search.pending.txt'));
						}
					}

				# offer "Click to rebuild":
				if (($$p_realm_data{'type'} != 5) and ($$p_realm_data{'has_base_url'})) {
					&pppstr(517, "$const{'admin_url'}&amp;Action=rebuild&amp;Realm=$$p_realm_data{'url_name'}");
					}

				if ($$p_realm_data{'type'} == 6) {
					# Filtered Realm
					# create a realm-specific Filter Rule, if none exist
					# link to the realm-specific Filter Rule

					my $fname = "$$p_realm_data{'name'} - limit";

					my $b_has_rule = 0;

					my $fr = &fdse_filter_rules_new();
					my $p_data = ();
					foreach $p_data ($fr->list_filter_rules()) {
						if ($fname eq $$p_data{'name'}) {
							$b_has_rule = 1;
							last;
							}
						}

					unless ($b_has_rule) {
						my @limits = ();
						$err = $fr->add_filter_rule(
							0,
							$fname,
							1,
							5,
							1,
							1,
							1,
							3,
							$$p_realm_data{'url_name'} . ',',
							\@limits,
							\@limits,
							);
						next Err if ($err);
						}


					my ($ufname, $hfname) = (&url_encode($fname), &he($fname));
					print qq!<p>This <b>Filtered Realm</b> must be restricted by filter rules to prevent it from indexing the entire web.</p>
					<p>The rule <a href="$const{'admin_url'}&amp;Action=FilterRules&amp;subaction=create_edit_rule&amp;name=$ufname">$hfname</a> has
					been created as a sample rule to get you started.</p><p>That filter rule is disabled by default. Before enabling it, you
					must enter some strings or patterns to describe the type of URL's that you would like to include in this realm.</p>\n!;


					}

				last Err;
				}
			last Err;
			}

		print <<"EOM";

	<p><b>$str[520]</b></p>
	<ul>
		<li><p><a href="$const{'admin_url'}&amp;Action=ManageRealms&amp;subaction=Create">$str[93]</a></p></li>
		<li><p><a href="$const{'admin_url'}&amp;Action=Edit">$str[94]</a></p></li>
		<li><p><a href="$const{'admin_url'}&amp;Action=DeleteRecord">$str[95]</a></p></li>
	</ul>
	<p><br /></p>

EOM


		my $p_realm_data = ();

		my (@filefed, @open_realms, @filtered_realms, @website_realms, @runtime_realms) = ();

		my @realms = ();

		@realms = $realms->listrealms('all');
		foreach $p_realm_data (@realms) {
			if ($$p_realm_data{'is_filefed'}) {
				push(@filefed, $p_realm_data);
				}
			elsif ($$p_realm_data{'type'} == 1) {
				push(@open_realms, $p_realm_data);
				}
			elsif ($$p_realm_data{'type'} == 6) {
				push(@filtered_realms, $p_realm_data);
				}
			elsif ($$p_realm_data{'is_runtime'}) {
				push(@runtime_realms, $p_realm_data);
				}
			else {
				push(@website_realms, $p_realm_data);
				}
			}

		@realms = $realms->listrealms('is_error');
		if (@realms) {
			&ppstr(64, $str[180] );
			foreach $p_realm_data (@realms) {
				print "<p><b>$$p_realm_data{'html_name'}</b> - $$p_realm_data{'err'}.</p><p>";
				&ppstr(182, "<a href=\"$const{'admin_url'}&amp;Action=ManageRealms&amp;Realm=$$p_realm_data{'url_name'}\">$str[411]</a>", "<a href=\"$const{'admin_url'}&amp;Action=ManageRealms&amp;Delete=$$p_realm_data{'url_name'}\" onclick=\"return confirm('$str[108]');\">$str[430]</a>" );
				print "</p>\n";
				}
			}

		if (@open_realms) {

			my $n_actions = 2;
			$n_actions++ if ($realms->{'need_approval'});

			my $suggest_rules = &pstr(107, "<a href=\"$const{'admin_url'}&amp;Action=FilterRules\">$str[162]</a>" );

print <<"EOM";

<p><b>$str[431]</b></p>

<p>$str[475]</p>
<p>$suggest_rules</p>

EOM
			print '<table border="1" cellpadding="4" cellspacing="1">';
			&print_realm_table_header();
			foreach $p_realm_data (@open_realms) {
				next if ($$p_realm_data{'is_error'});
				&print_realm_table_row($p_realm_data);
				}
			print '</table><p><br /></p>';
			}



		if (@filtered_realms) {

			my $n_actions = 2;
			$n_actions++ if ($realms->{'need_approval'});

print <<"EOM";

<p><b>$str[268]</b></p>

<p>$str[527]</p>

EOM
			print '<table border="1" cellpadding="4" cellspacing="1">';
			&print_realm_table_header();
			foreach $p_realm_data (@filtered_realms) {
				next if ($$p_realm_data{'is_error'});
				&print_realm_table_row($p_realm_data);
				}
			print '</table><p><br /></p>';
			}







		if (@website_realms) {

print <<"EOM";

<p><b>$str[474]</b></p>

<p>$str[471]</p>

EOM
			print '<table border="1" cellpadding="4" cellspacing="1">';
			&print_realm_table_header();
			foreach $p_realm_data (@website_realms) {
				next if ($$p_realm_data{'is_error'});
				&print_realm_table_row($p_realm_data);
				}
			print '</table><p><br /></p>';
			}

		if (@runtime_realms) {

print <<"EOM";

<p><b>$str[513]</b></p>

<p>$str[212]</p>

EOM
			print '<table border="1" cellpadding="4" cellspacing="1">';
			&print_realm_table_header();
			foreach $p_realm_data (@runtime_realms) {
				next if ($$p_realm_data{'is_error'});
				&print_realm_table_row($p_realm_data);
				}
			print '</table><p><br /></p>';
			}


		if (@filefed) {

print <<"EOM";

<p><b>$str[489]</b></p>

<p>$str[208]</p>

EOM
			print '<table border="1" cellpadding="4" cellspacing="1">';
			&print_realm_table_header();
			foreach $p_realm_data (@filefed) {
				next if ($$p_realm_data{'is_error'});
				&print_realm_table_row($p_realm_data);
				}
			print '</table><p><br /></p>';
			}

		&ui_GeneralRules( $str[520], 'ManageRealms', 'show advanced commands', 'delete index file with realm' );
		last Err;
		}
	return $err;
	}





sub print_realm_table_header {
	my ($name) = @_;
	print "<tr><th>$str[190]</th><th width=\"240\">";
	print defined($name) ? $name : $str[428];
	print '</th>';

if ($Rules{'sql: enable'}) {

print <<"EOM";
	<th>$str[156]</th>
EOM

	}
else {

print <<"EOM";
	<th>$str[153]</th>
	<th>$str[156]</th>
	<th>$str[113]</th>
EOM

	}

	print <<"EOM";
	<th>$str[146]</th>
</tr>

EOM

	}





sub print_realm_table_row {
	my ($p_realm_data) = @_;
	my $index_size_bytes = 0;
	my $pages = '<center>-</center>';
	my $size = '<center>-</center>';
	my $lastmodtime = '-';
	if ($$p_realm_data{'has_file'}) {
		$index_size_bytes = -s $$p_realm_data{'file'};
		$size = &FormatNumber( (1023 + $index_size_bytes) / 1024, 0, 1, 0, 1, $Rules{'ui: number format'} );
		my $lastmodt = (stat($$p_realm_data{'file'}))[9];
		$lastmodtime = &FormatDateTime( $lastmodt, $Rules{'ui: date format'} );
		$lastmodtime .= '<br />' . &get_age_str( time() - $lastmodt );
		}
	unless ($$p_realm_data{'is_runtime'}) {
		$pages = &FormatNumber( $$p_realm_data{'pagecount'}, 0, 1, 0, 1, $Rules{'ui: number format'} );
		}


	my $h_base_url = (($$p_realm_data{'type'} == 1) or ($$p_realm_data{'type'} == 6)) ? '-' : $$p_realm_data{'base_url'};
	#changed 0054 - substr to 65 chars
	if (64 < length($h_base_url)) {
		$h_base_url = substr($h_base_url,0,64) . '...';
		}
	$h_base_url = &he($h_base_url);

	#changed 0056 - substr to 65 chars for name as well
	my $hname = $$p_realm_data{'html_name'};
	if (64 < length($$p_realm_data{'name'})) {
		$hname = &he( substr($$p_realm_data{'name'},0,64) . '...' );
		}




print <<"EOM";

<tr class="fdtan">
	<td align="center"><a href="$const{'admin_url'}&amp;Action=ManageRealms&amp;subaction=Edit&amp;Realm=$$p_realm_data{'url_name'}" class="onbrown">$str[411]</a></td>
	<td rowspan="2" nowrap="nowrap">
		<b>$hname</b><br />$h_base_url</td>

EOM

if ($Rules{'sql: enable'}) {

print <<"EOM";
	<td align="right" rowspan="2">$pages</td>
EOM

	}
else {

print <<"EOM";
	<td align="right" rowspan="2" nowrap="nowrap">$size KB</td>
	<td align="right" rowspan="2">$pages</td>
	<td align="center" rowspan="2">$lastmodtime</td>
EOM

	}

print <<"EOM";

	<td nowrap="nowrap">
		<a href="$const{'admin_url'}&amp;Action=Review&amp;Realm=$$p_realm_data{'url_name'}" class="onbrown">$str[154]</a>

EOM

print <<"EOM" if ($$p_realm_data{'need_approval'});

- <a href="$const{'admin_url'}&amp;Action=FilterRules&amp;subaction=ShowPending&amp;Realm=$$p_realm_data{'url_name'}" class="onbrown">$str[427]</a>

EOM


print <<"EOM";
	</td>
</tr>
<tr class="fdtan">
	<td align="center"><a href="$const{'admin_url'}&amp;Action=ManageRealms&amp;Delete=$$p_realm_data{'url_name'}" onclick="return confirm('$str[108]');" class="onbrown">$str[430]</a></td>

EOM

if ($$p_realm_data{'is_runtime'}) {
	print '<td><br /></td>';
	}
else {
print <<"EOM";

	<td nowrap="nowrap"><a href="$const{'admin_url'}&amp;Action=rebuild&amp;DaysPast=0&amp;Realm=$$p_realm_data{'url_name'}" class="onbrown">$str[123]</a> - <a href="$const{'admin_url'}&amp;Action=rebuild&amp;DaysPast=$Rules{'crawler: days til refresh'}&amp;Realm=$$p_realm_data{'url_name'}" class="onbrown">$str[124]</a></td>

EOM
		}
	print '</tr>';
	return $index_size_bytes;
	}





sub ui_AdminPage {

	print qq!<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> / $str[443]</b></p>\n!;

	&pppstr(533, "$const{'help_file'}1150.html" );

	my $err = '';
	Err: {

		my $i = 0;

		$err = $realms->{'last_realm_err'};
		next Err if ($err);

		my $p_realm_data = ();

		my (@filefed, @open_realms, @filtered_realms, @website_realms, @runtime_realms) = ();

		my @realms = ();

		@realms = $realms->listrealms('all');
		foreach $p_realm_data (@realms) {
			if ($$p_realm_data{'is_filefed'}) {
				push(@filefed, $p_realm_data);
				}
			elsif ($$p_realm_data{'type'} == 1) {
				push(@open_realms, $p_realm_data);
				}
			elsif ($$p_realm_data{'type'} == 6) {
				push(@filtered_realms, $p_realm_data);
				}
			elsif ($$p_realm_data{'is_runtime'}) {
				push(@runtime_realms, $p_realm_data);
				}
			else {
				push(@website_realms, $p_realm_data);
				}
			}

		@realms = $realms->listrealms('is_error');
		if (@realms) {
			&ppstr(64, $str[180] );
			foreach $p_realm_data (@realms) {
				print "<p><b>$$p_realm_data{'html_name'}</b> - $$p_realm_data{'err'}.</p>\n";
				&pppstr(182, "<a href=\"$const{'admin_url'}&amp;Action=ManageRealms&amp;Realm=$$p_realm_data{'url_name'}\">$str[411]</a>", "<a href=\"$const{'admin_url'}&amp;Action=ManageRealms&amp;Delete=$$p_realm_data{'url_name'}\" onclick=\"return confirm('$str[108]');\">$str[430]</a>" );
				}
			}

		#changed 0054 -- allow website, file-fed, filtered, and open realms to use Add New URL form
		my $count = 0;
		my $ChooseRealmLine = '';

		my $p_data;
		foreach $p_data ($realms->listrealms('all')) {
			next if (($$p_data{'type'} == 4) or ($$p_data{'type'} == 5));
			$ChooseRealmLine .= qq!<option value="$$p_data{'html_name'}">$$p_data{'html_name'}</option>\n!;
			$count++;
			}



		my $ref_manage_realms = &pstr(371, qq!<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a>! );


# the "Add New URL" form appears in all non-Freeware versions and in Freeware if there are valid realms which can accept
# single URL additions (count > 0)
if ((($const{'mode'} != 3) or ($count)) and ($Rules{'use socket routines'})) {


		my $input = qq!<textarea name="URL" rows="3" cols="40" style="wrap:soft">http://</textarea>!;
		if (($Rules{'show advanced commands'}) or (not $Rules{'multi-line add-url form - admin'})) {
			$input = qq!<input name="URL" value="http://" size="40" />!;
			}


print <<"EOM";

<p><b>$str[172]</b></p>
<blockquote>

	<p>$str[291]</p>

$const{'AdminForm'}
<input type="hidden" name="Action" value="AddURL" />

	<table border="0">
	<tr>
		<td align="right"><b>$str[74]:</b></td>
		<td>$input</td>
	</tr>

EOM

print <<"EOM" if ($count);

	<tr>
		<td align="right"><b>$str[531]:</b></td>
		<td><select name="Realm">$ChooseRealmLine</select></td>
	</tr>

EOM

print <<"EOM" if ($Rules{'show advanced commands'});
	<tr>
		<td><br /></td>
		<td><input type="checkbox" name="EntireSite" value="1" /> $str[429]</td>
	</tr>
EOM

print <<"EOM";
	<tr>
		<td><br /></td>
		<td><input type="submit" class="submit" value="$str[172]" /></td>
	</tr>
	</table>

	</form>
</blockquote>

EOM
	}



# the "Add New Site" form:

if ((($const{'mode'} != 3) or (0 == $realms->realm_count('all'))) and ($Rules{'use socket routines'})) {

print <<"EOM";

<p><b>$str[290]</b></p>
<blockquote>
	<p>$str[287]</p>

$const{'AdminForm'}

	<input type="hidden" name="Action" value="AddURL" />
	<input type="hidden" name="EntireSite" value="1" />
	<input type="hidden" name="CreateSelectRealm" value="1" />
	<table border="0">
	<tr>
		<td align="right"><b>$str[74]:</b></td>
		<td><tt><input name="URL" value="http://" size="40" /></tt></td>
	</tr>
	<tr>
		<td><br /></td>
		<td><input type="submit" class="submit" value="$str[290]" /></td>
	</tr>
	</table>

</form>

</blockquote>

EOM
	}

print <<"EOM";


<p><b>$str[377]</b></p>

<p>$str[521]</p>
<p>$ref_manage_realms</p>

EOM

print '<table border="1" cellpadding="4" cellspacing="1">' if (@open_realms or @filtered_realms or @website_realms or @runtime_realms or @filefed);

		my $total_size = 0;
		my $total_pages = 0;
		my $realm_count = 0;

		if (@open_realms) {
			&print_realm_table_header($str[431]);
			foreach $p_realm_data (@open_realms) {
				next if ($$p_realm_data{'is_error'});
				$total_size += &print_realm_table_row($p_realm_data);
				$realm_count++;
				$total_pages += $$p_realm_data{'pagecount'};
				}
			}
		if (@filtered_realms) {
			&print_realm_table_header($str[268]);
			foreach $p_realm_data (@filtered_realms) {
				next if ($$p_realm_data{'is_error'});
				$total_size += &print_realm_table_row($p_realm_data);
				$realm_count++;
				$total_pages += $$p_realm_data{'pagecount'};
				}
			}
		if (@website_realms) {
			&print_realm_table_header($str[474]);
			foreach $p_realm_data (@website_realms) {
				next if ($$p_realm_data{'is_error'});
				$total_size += &print_realm_table_row($p_realm_data);
				$realm_count++;
				$total_pages += $$p_realm_data{'pagecount'};
				}
			}
		if (@runtime_realms) {
			&print_realm_table_header($str[513]);
			foreach $p_realm_data (@runtime_realms) {
				next if ($$p_realm_data{'is_error'});
				$total_size += &print_realm_table_row($p_realm_data);
				$realm_count++;
				$total_pages += $$p_realm_data{'pagecount'};
				}
			}
		if (@filefed) {
			&print_realm_table_header($str[489]);
			foreach $p_realm_data (@filefed) {
				next if ($$p_realm_data{'is_error'});
				$total_size += &print_realm_table_row($p_realm_data);
				$realm_count++;
				$total_pages += $$p_realm_data{'pagecount'};
				}
			}

if ($realm_count) {

		$total_size = &FormatNumber( (1023 + $total_size) / 1024, 0, 1, 0, 1, $Rules{'ui: number format'} );
		$total_pages = &FormatNumber( $total_pages, 0, 1, 0, 1, $Rules{'ui: number format'} );

print <<"EOM";

<tr>
	<th><br /></th>
	<th>Totals</th>
	<th>Size</th>
	<th>Pages</th>
	<th><br /></th>
	<th><br /></th>
</tr>
<tr class="fdtan">
	<td><br /></td>
	<td><br /></td>
	<td nowrap="nowrap" align="right">$total_size KB</td>
	<td nowrap="nowrap" align="right">$total_pages</td>
	<td><br /></td>
	<td><br /></td>
</tr>


EOM

	}

		print '</table>' if (@open_realms or @filtered_realms or @website_realms or @runtime_realms or @filefed);
		last Err;
		}
	continue {
		&ppstr(64, $err );
		}


print <<"EOM";

	<p><br /></p>

EOM
	}





sub ui_PersonalSettings {
	my $err = '';
	Err: {
		local $_;

print <<"EOM";

<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=PS">$str[183]</a>
EOM

		my $subaction = $FORM{'subaction'} || '';

		if ($subaction eq 'SaveData') {
			print " / $str[362]</b></p>\n";


			if ($FORM{'admin notify: sendmail program'}) {
				my $b_is_valid = 0;
				foreach (@sendmail) {
					$b_is_valid = 1 if ($_ eq $FORM{'admin notify: sendmail program'});
					}
				unless ($b_is_valid) {
					$err = &pstr(144, &he($FORM{'admin notify: sendmail program'}) );
					next Err;
					}
				}

			foreach ('admin notify: email address', 'admin notify: smtp server', 'admin notify: sendmail program') {
				$err = &WriteRule($_,$FORM{$_} || '');
				next Err if ($err);
				&ppstr(174, &pstr(404,&he($_, $FORM{$_})));
				}
			foreach ('security: session timeout') {
				$err = &WriteRule($_,$FORM{$_} || 0);
				next Err if ($err);
				&ppstr(174, &pstr(404,&he($_,$FORM{$_})));
				}

			if (($FORM{'op'}) and ($FORM{'np'}) and ($FORM{'cp'})) {

				if ($const{'is_demo'}) {
					&ppstr(53, $str[435] );
					last Err;
					}

				my $seed = 'sX';
				if ($FORM{'np'} ne $FORM{'cp'}) {
					&ppstr(64, $str[285] );
					}
				elsif ($Rules{'password'} eq crypt($FORM{'op'}, $seed)) {
					# well, okay so far:

					my $newpass = crypt($FORM{'np'}, $seed);

					$err = &WriteRule( 'password', $newpass );
					next Err if ($err);
					&ppstr(174, $str[538] );
					}
				else {
					&ppstr(64, $str[181] );
					}
				}


			last Err;
			}

		if ($subaction eq 'TestMail') {
			print qq! / <a href="$const{'admin_url'}&amp;Action=PS&amp;subaction=TestMail">$str[168]</a></b></p>\n!;

my $test_msg = <<"EOM";
Hello!

This is a test message from your search engine. The following options were used to send it:

   Email address: $Rules{'admin notify: email address'}
     SMTP server: $Rules{'admin notify: smtp server'}
Sendmail Program: $Rules{'admin notify: sendmail program'}

EOM

			my $trace = '';

			($err, $trace) = &SendMailEx(
				'handler_order' => '12',
				'to'  => $Rules{'admin notify: email address'},
				'from' => $Rules{'admin notify: email address'},
				'host' => $Rules{'admin notify: smtp server'},
				'pipeto' => $Rules{'admin notify: sendmail program'},
				'p_nc_cache' => $const{'p_nc_cache'},
				'use standard io' => $Rules{'use standard io'},
				'subject' => "Test Message from search engine",
				'message' => $test_msg,
				);
			next Err if ($err);

			$trace = &he( $trace );

			&ppstr(174, $str[116] );
			print qq!<p>$str[117]</p><p><textarea rows="10" cols="65">$trace</textarea></p>\n!;

			last Err;
			}

print <<"EOM";

	/ $str[152]</b></p>

$const{'AdminForm'}
<input type="hidden" name="Action" value="PS" />
<input type="hidden" name="subaction" value="SaveData" />

EOM

		$const{'sendmail_options'} = '<option value="">[ None ]</option>';
		foreach (sort @sendmail) {
			next unless (m!^(\S+)!);
			next unless (-e $1);
			$const{'sendmail_options'} .= '<option value="' . &he($_) . '">' . &he($_) . '</option>';
			}


		my $text = &PrintTemplate( 1, 'admin_personal.txt', $Rules{'language'}, \%const );
		print &SetDefaults($text, \%Rules);
		print '</form>';
		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}



sub ui_testxpdf {
	my $err = '';
	Err: {

print <<"EOM";

<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=SI">$str[494]</a> /
	<a href="$const{'admin_url'}&amp;Action=TXPDF">Test Xpdf Integration</a></b></p>

<p>This interface contains some audit routines for searching PDF files using the Xpdf utilities.  There is a help file with <a href="$const{'help_file'}1092.html">more information on Xpdf integration</a>.</p>

EOM


		my $hpath = &he($private{'pdf utility folder'});

		print qq!<p>The 'pdf utility folder' setting is set to '$hpath'.</p>\n!;

		if ($hpath =~ m!\s!) {
			$err = "the Xpdf folder '$hpath' contains whitespace. This is not supported";
			next Err;
			}

		if ($hpath eq '') {
			print qq!<p>The string is empty.  Xpdf is not integrated with this script.</p>\n!;
			last Err;
			}

		# file existence test:
		print qq!<p>The -e file existence test returns ! . ((-e $private{'pdf utility folder'}) ? 'true' : 'FALSE') . qq! on this path.</p>\n!;
		print qq!<p>The -d is-directory test returns ! . ((-d $private{'pdf utility folder'}) ? 'true' : 'FALSE') . qq! on this path.</p>\n!;


		if ($private{'pdf utility folder'} !~ m!(\\|/)$!) {
			print qq!<p><b>Warning:</b> the path "$hpath" does not end in a trailing slash of "\\" or "/".  This setting must have a proper trailing slash.</p>\n!;
			}

		# slash convention:
		my ($good, $bad) = ("/", "\\");
		if ($^O =~ m!mswin!i) {
			print qq!<p>Perl's <code>\$^O</code> operating system variable returns $^O. This pattern matches to m/mswin/.  Assuming Microsoft Windows.  Assuming backslash convention "\\" as folder separator.</p>\n!;
			($good, $bad) = ("\\", "/");
			}
		else {
			print qq!<p>Perl's <code>\$^O</code> operating system variable returns $^O. This does not pattern match to m/mswin/.  Assuming <em>not</em> Microsoft Windows.  Assuming forward slash convention "/" as folder separator.</p>\n!;
			}
		my $qmbad = quotemeta($bad);
		my $qmgood = quotemeta($good);
		if ($private{'pdf utility folder'} =~ m!$qmbad!) {
			print qq!<p><b>Warning:</b> path "$hpath" contains slash characters "$bad" which don't appear native to this platform.  The native slash convention must be used because this path string will be used to shell out to the operating system.  The operating system will not be as tolerant as you or I in equating "/" and "\\" as folder separators.</p>\n!;
			}
		elsif ($private{'pdf utility folder'} =~ m!$qmgood!) {
			print qq!<p>Path "$hpath" contains native slash convention; it matches "$good" and does not match "$bad".  Great job\!</p>\n!;
			}
		else {
			print qq!<p>Path "$hpath" contains neither slash "$good" nor "$bad". Odd.</p>\n!;
			}

		my @files = ('pdfinfo','pdfinfo.exe','pdftotext','pdftotext.exe');

		print "<p>Performing discovery tests on individual executable files...</p>\n";

		foreach (@files) {
			my $full = $private{'pdf utility folder'} . $_;
			my $hfull = &he($full);
			print "<p><b>$hfull</b></p>\n";
			if (-e $full) {
				print "<p>-e file existence: TRUE</p>\n";
				if (-X $full) {
					print "<p>-X is-executable: TRUE</p>\n";
					}
				else {
					print "<p>-X is-executable: FALSE</p>\n";
					}
				}
			else {
				print "<p>-e file existence: FALSE</p>\n";
				}
			}

		print "<p>Now making system calls to test inter-operability...</p><p>This script will shell out to the commands, without any arguments.  The utilities should return their usage syntax.  They may return information on STDERR; that is normal for usage information.  If no information is captured in the return, then either the scripts are not executable, or Perl is unable to capture the STDERR/STDOUT output of another file, or something.</p>\n";

		&get_command_out( "$private{'pdf utility folder'}pdfinfo", 1 );
		&get_command_out( "$private{'pdf utility folder'}pdftotext", 1 );

		print qq!<p>If you have sockets enabled on your server, you may be able to follow <a href="$const{'admin_url'}&amp;Action=AddURL&amp;URL=http://xav.com/scripts/search/pl2000.pdf&amp;debug=1">this link</a> to debug an actual PDF parsing operation.  Whenever the debug=1 parameter is present, the PDF parsing will be done in debug mode where all output is shown on screen.</p>\n!;

		last Err;
		}
	return $err;
	}



sub ui_sysinfo {

print <<"EOM";
<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=SI">$str[494]</a> / $str[152]</b></p>

EOM

	&pppstr(488, $], $^X, $^O, &query_env('SERVER_SOFTWARE'));

	my $xpdf = $private{'pdf utility folder'} ? $private{'pdf utility folder'} : '[none]';

print <<"EOM";

<table border="1" cellpadding="4" cellspacing="0">
<tr>
	<td align="right"><b>Data Folder:</b></td>
	<td>$private{'support_dir'}</td>
	<td><a href="$const{'help_file'}1079.html">$str[432]</a></td>
</tr>
<tr>
	<td align="right"><b>XPDF Folder:</b></td>
	<td>$xpdf</td>
	<td><a href="$const{'help_file'}1092.html">$str[432]</a> | <a href="$const{'admin_url'}&amp;Action=TXPDF">Test</a></td>
</tr>
</table>

<p><b>$str[495]</b></p>

<table border="1" cellpadding="4" cellspacing="0">

EOM

	foreach (sort keys %ENV) {
		print qq!<tr><td align="right">$_</td><td>$ENV{$_}<br /></td></tr>\n!;
		}
	print "</table>";
	}





sub ui_GeneralRules {

	my ($name, $action, @settings) = @_;

	# FORM{'gr1'} takes prec -> name
	# FORM{'gr0'} takes prec -> action

	# initialize:
	$FORM{'gr1'} = &he($name || $FORM{'gr1'} || '');
	$FORM{'gr0'} = &he($action || $FORM{'gr0'} || '');

	my $ugr1 = &url_encode($FORM{'gr1'});

	my $top_name = $name || $FORM{'gr1'} || $str[159];
	my $top_action = $action || $FORM{'gr0'} || 'GeneralRules';

	my $err = '';
	Err: {

		# Load Fluid Dynamics Rules object:

		my $FDR = &FD_Rules_new();
		my $r_defaults = $FDR->get_defaults();
		my (@names, %descriptions) = ();
		$err = $FDR->load_desc( \@names, \%descriptions );
		next Err if ($err);


		my $sa = $FORM{'subaction'} || '';


		# Print the header, *unless* this is an inline-list request (only those requests have $name initialized)

		unless ($name) {

print <<"EOM";

<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=$top_action&amp;gr1=$ugr1&amp;gr0=$FORM{'gr0'}">$top_name</a>

EOM
			if ($FORM{'Edit'}) {
				my $html_name = &he( $FORM{'Edit'} );
				print " / <a href=\"$const{'admin_url'}&amp;Action=GeneralRules&amp;gr1=$ugr1&amp;gr0=$FORM{'gr0'}&amp;Edit=$html_name\">$html_name</a>";
				}
			if ($sa eq 'Write') {
				print " / $str[362]</b></p>\n";
				}
			else {
				print " / $str[152]</b></p>\n";
				}
			}


		if ($FORM{'Edit'}) {

			my $name = $FORM{'Edit'};
			my $lc_name = lc($name);
			my $html_name = &he($name);
			my $type = $$r_defaults{$lc_name}[1];

			if ($sa eq 'Write') {

				my %rebuild_warning = (
					'allowbinaryfiles' => 1,
					'allowsymboliclinks' => 1,
					'crawler: follow offsite links' => 1,
					'crawler: follow query strings' => 1,
					'crawler: ignore links to' => 1,
					'crawler: minimum whitespace' => 1,
					'crawler: rogue' => 1,
					'ext' => 1,
					'index alt text' => 1,
					'index links' => 1,
					'max characters: auto description' => 1,
					'max characters: description' => 1,
					'max characters: file' => 1,
					'max characters: keywords' => 1,
					'max characters: text' => 1,
					'max characters: title' => 1,
					'max characters: url' => 1,
					'minimum page size' => 1,
					'parse fdse-index-as header' => 1,
					'trustsymboliclinks' => 1,
					'ignore words' => 2,
					);

				if (($lc_name eq 'no frames') and ($const{'is_demo'})) {
					&ppstr(53, $str[435] );
					last Err;
					}

				my $value = $FORM{'VALUE'};

				if ($type == 1) {
					$value = ($value) ? 1 : 0;
					}

				# strip line breaks, as promised:
				$value =~ s!(\n|\r|\015|\012)! !sg;

				my $b_changed = ($Rules{$lc_name} ne $value) ? 1 : 0;
				$err = &WriteRule( $lc_name, $value );
				next Err if ($err);

				&ppstr(174, &pstr(404,$html_name,&he($value)));

				if (($rebuild_warning{$lc_name}) and ($b_changed)) {
					if ($rebuild_warning{$lc_name} == 1) {
						print '<p>' . $str[519] . '</p>';
						}
					else {
						print '<p>' . $str[518] . '</p>';
						}
					}

				last Err;
				}

			my $value = $Rules{$lc_name};
			my $def_value = $$r_defaults{$lc_name}[0];

			my @type_desc = (
				0,
				$str[392],
				$str[393],
				$str[394],
				$str[395],
				$str[396],
				);

			my $minmax = '';


			if ($type == 3) {
				$minmax = " ($str[405] " . $$r_defaults{$lc_name}[2] . "; $str[406] " . $$r_defaults{$lc_name}[3] . ")";
				}

			my %defaults = (
				'VALUE' => $Rules{$lc_name},
				);


print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="GeneralRules" />
<input type="hidden" name="Edit" value="$html_name" />
<input type="hidden" name="subaction" value="Write" />
<input type="hidden" name="gr1" value="$FORM{'gr1'}" />
<input type="hidden" name="gr0" value="$FORM{'gr0'}" />

EOM

			# if Boolean checkbox value:
			if ($type == 1) {

print &SetDefaults(<<"EOM", \%defaults);
<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2" align="left">$str[402]</th>
</tr>
<tr>
	<td><input type="checkbox" name="VALUE" value="1" id="VALUE_1" /></td>
	<td><label for="VALUE_1"><b>$html_name</b></label></td>
</tr>
</table>
<p>$descriptions{lc($name)}</p>
<p><input type="submit" class="submit" value="$str[362]" /></p>
</form>

EOM

				# option to restore default with single click:
				if ($value ne $def_value) {
					&pppstr(401, "<a href=\"$const{'admin_url'}&amp;Action=GeneralRules&amp;Edit=$html_name&amp;VALUE=$def_value&amp;subaction=Write&amp;gr1=$ugr1&amp;gr0=$FORM{'gr0'}\">$str[193]</a>" );
					}
				else {
					print "<p>$str[501]</p>\n";
					}
				}

			# otherwise, if not a Boolean value (string/int/text):
			else {

				my $form_element = '<input name="VALUE" />';
				if ((40 < length($value)) or (40 < length($def_value))) {
					$form_element = '<textarea name="VALUE" rows="5" cols="60" style="wrap:soft"></textarea>';
					}
				elsif (($type == 2) or ($type == 3)) {
					$form_element = '<input name="VALUE" size="8" style="text-align:right" />';
					}



print &SetDefaults(<<"EOM", \%defaults);

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2" align="left">$str[159]: $html_name</th>
</tr>
<tr>
	<td width="120" align="right" valign="top"><b>$str[428]:</b></td>
	<td><b>$html_name</b></td>
</tr>
<tr>
	<td align="right" valign="top"><b>$str[63]:</b></td>
	<td>$descriptions{lc($name)}</td>
</tr>
<tr>
	<td align="right" valign="top"><b>$str[157]:</b></td>
	<td>$type_desc[$type]$minmax</td>
</tr>
</table>

<table border="0" cellpadding="4" cellspacing="2">
<tr>
	<td width="120" align="right" valign="top"><b>$str[492]:</b></td>
	<td>$form_element</td>
</tr>
<tr>
	<td><br /></td>
	<td><p><input type="submit" class="submit" value="$str[362]" /></p></td>
</tr>
</table>

</form>
EOM

				if ($value ne $def_value) {
					$defaults{'VALUE'} = $def_value;

print &SetDefaults(<<"EOM", \%defaults);
$const{'AdminForm'}
<input type="hidden" name="Action" value="GeneralRules" />
<input type="hidden" name="Edit" value="$html_name" />
<input type="hidden" name="subaction" value="Write" />
<input type="hidden" name="gr1" value="$FORM{'gr1'}" />
<input type="hidden" name="gr0" value="$FORM{'gr0'}" />

<table border="0" cellpadding="4" cellspacing="2">
<tr>
	<td width="120" align="right" valign="top"><b>$str[97]:</b></td>
	<td>$form_element</td>
</tr>
<tr>
	<td><br /></td>
	<td><input type="submit" class="submit" value="$str[375]" /></td>
</tr>
</table>

</form>


EOM

					}
				else {
					print "<p>$str[501]</p>\n";
					}
				print "<p>" . $str[403] . "</p>\n";
				}
			last Err;
			}

		my $show_all_opt = 0;
		unless (@settings) {
			$show_all_opt = 1;
			@settings = (
				'allowbinaryfiles',
				'allowsymboliclinks',
				'crawler: days til refresh',
				'crawler: follow offsite links',
				'crawler: follow query strings',
				'crawler: ignore links to',
				'crawler: max pages per batch',
				'crawler: max redirects',
				'crawler: minimum whitespace',
				'crawler: rogue',
				'crawler: user agent',
				'ext',
				'forbid all cap descriptions',
				'forbid all cap titles',
				'ignore words',
				'index alt text',
				'index links',
				'max characters: auto description',
				'max characters: description',
				'max characters: file',
				'max characters: keywords',
				'max characters: text',
				'max characters: title',
				'max characters: url',
				'max index file size',
				'minimum page size',
				'multi-line add-url form - admin',
				'multi-line add-url form - visitors',
				'multiplier: description',
				'multiplier: keyword',
				'multiplier: title',
				'multiplier: url',
				'network timeout',
				'parse fdse-index-as header',
				'redirector',
				'time interval between restarts',
				'timeout',
				'trustsymboliclinks',
				'use standard io',
				'use dbm routines',
				'use socket routines',
				'wildcard match',
				);
			}
		my %show_settings = ();
		foreach (@settings) {
			$show_settings{$_} = 1;
			}


		if ($show_all_opt) {
			print '<p>';
			&ppstr(488, $], $^X, $^O, &query_env('SERVER_SOFTWARE'));
			print "<br />[ <a href=\"$const{'admin_url'}&amp;Action=SI\">$str[496]</a> ]</p>\n";
			}

		my $name = '';
		foreach $name (sort @names) {
			my $lc_name = lc($name);

			next unless ($show_settings{$lc_name});

			my $url_name = &url_encode($name);
			my $html_name = &he($name);
			my $default = $$r_defaults{$lc_name}[0];
			my $current_val = $Rules{$lc_name};


			my $def = '';
			if ($current_val eq $default) {
				$def = " (<span class=\"defaultsetting\">$str[234]</span>) ";
				}
			else {
				$def = " (<span class=\"customsetting\">$str[223]</span>) ";
				}

			my $display_val = $current_val;
			if (length($current_val) > 15) {
				$display_val = substr($current_val, 0, 12) . "...";
				}
			$display_val = &he($display_val);

			print "<p>[ <a href=\"$const{'admin_url'}&amp;Action=GeneralRules&amp;Edit=$url_name&amp;gr1=$ugr1&amp;gr0=$FORM{'gr0'}\">$str[411]</a> ] <b>$html_name</b> = $display_val $def<br />$descriptions{$lc_name}</p>\n";
			}

		if ($show_all_opt) {
			print "<blockquote><p>$str[486]: <a href=\"$const{'admin_url'}&amp;Action=UserInterface&amp;subaction=viewmap\"><b>$str[473]</b></a></p></blockquote>\n";
			}

		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}





sub update_file {
	my ($realm, $ref_crawler_results) = @_;

	my ($total_records, $new_records, $updated_records, $deleted_records) = (0, 0, 0, 0);

	my $err = '';
	Err: {
		local $_;

		my $p_realm_data = ();
		($err, $p_realm_data) = $realms->hashref($realm);
		next Err if ($err);

		unless ($$p_realm_data{'file'}) {
			$err = &pstr(141, $$p_realm_data{'html_realm'} );
			next Err;
			}

		my $obj = &LockFile_new();

		my ($p_rhandle, $p_whandle) = ();
		($err, $p_rhandle, $p_whandle) = $obj->ReadWrite( $$p_realm_data{'file'} );
		next Err if ($err);

		my $TempFile = $obj->get_wname();

		WriteF: {

			my $ref_data = ();

			while (defined($_ = readline($$p_rhandle))) {
				# compare whether an existing entry is there:
				next unless (m!u= (.*?) t=!); # skip invalid lines and isolate URL
				my $record_url = $1;
				if ($ref_data = $$ref_crawler_results{$record_url}) {

					if ($$ref_data{'b_write_to_temp'}) {
						# oh, this crawler result is a write-to-temp... do nothing here
						}
					else {

						if (($$ref_data{'is_error'}) or ($$ref_data{'experienced'})) {
							$$ref_data{'sub status msg'} = $str[408];
							$deleted_records++;
							next;
							}

						$$ref_data{'experienced'} = 1;

						if ($$ref_data{'is_update'}) {

							# Create a new replacement record:
							if (m!^(\d+) (\d+) (\d+) u= .*? t= .*? d= .*? uM= .*? uT= .*? uD= .*? uK= .*? h= (.*?) l= (.*)!) {

								my ($promote, $dd, $mm, $yyyy) = unpack('A2A2A2A4', $1);
								$$ref_data{'lastmodtime'} = $2;
								$$ref_data{'lastindex'} = $3;
								$$ref_data{'text'} = $4;
								$$ref_data{'links'} = $3;

								#$$ref_data{'promote'} = $promote;

								$$ref_data{'dd'} = $dd;
								$$ref_data{'mm'} = $mm;
								$$ref_data{'yyyy'} = $yyyy;

								}

							#revcompat - older yet support record format
							elsif (m!^(\d+) u= .*? t= .*? d= .*? uM= .*? uT= .*? uD= .*? uK= .*? h= (.*?) l= (.*)!) {
								my ($promote, $dd, $mm, $yyyy) = unpack('A2A2A2A4', $1);
								#$$ref_data{'promote'} = $promote;
								$$ref_data{'dd'} = $dd;
								$$ref_data{'mm'} = $mm;
								$$ref_data{'yyyy'} = $yyyy;
								$$ref_data{'text'} = $2;
								$$ref_data{'links'} = $3;
								}
							#/revcompat

							else {
								&ppstr(64, $str[409] );
								next;
								}
							}
						$$ref_data{'is_update'} = 1;

						my ($temp_err_msg, $text_record) = &text_record_from_hash( $ref_data );
						if ($temp_err_msg) {
							&ppstr(64, $temp_err_msg );
							next;
							}

						$_ = $text_record;
						$$ref_data{'sub status msg'} = $str[312];
						$updated_records++;
						}
					}

				unless (print { $$p_whandle } $_) {
					$err = &pstr(43, $TempFile, $!);
					next WriteF;
					}
				$total_records++;
				}
			#end changes

			my ($URL, $ref_pagedata) = ();
			while (($URL, $ref_pagedata) = each %$ref_crawler_results) {
				next if (($$ref_pagedata{'is_error'}) or ($$ref_pagedata{'is_update'}) or ($$ref_pagedata{'b_write_to_temp'}));
				if ($$ref_pagedata{'record'}) {
					unless (print { $$p_whandle } $$ref_pagedata{'record'}) {
						$err = &pstr(43,$TempFile,$!);
						next WriteF;
						}
					}
				else {
					my ($temp_err_msg, $record) = &text_record_from_hash( $ref_pagedata );
					if ($temp_err_msg) {
						$$ref_pagedata{'sub status msg'} = $temp_err_msg;
						next;
						}
					else {
						unless (print { $$p_whandle } $record) {
							$err = &pstr(43,$TempFile,$!);
							next WriteF;
							}
						}
					}
				unless ($$ref_pagedata{'sub status msg'}) {
					$$ref_pagedata{'sub status msg'} = $str[407];
					}
				$new_records++;
				$total_records++;
				}
			last WriteF;
			}

		# was there an error during the write? if so that's too bad - better abort and call it a day
		if ($err) {
			my $cancel_msg = $obj->Cancel();
			if ($cancel_msg) {
				$err .= "</p><p><b>$str[73]:</b> $cancel_msg";
				}
			next Err;
			}

		# has our file grown too big?

		my $TempSize = -s $TempFile;

		# zero max size negates size checking
		if (($Rules{'max index file size'}) and ($TempSize > $Rules{'max index file size'})) {
			# The temp file is too big - abort everything:

			my $max_size = &FormatNumber( $Rules{'max index file size'}, 0, 1, 0, 1, $Rules{'ui: number format'} );

			$TempSize = &FormatNumber( $TempSize , 0, 1, 0, 1, $Rules{'ui: number format'} );
			$err = &pstr(410, $max_size, $$p_realm_data{'file'}, $TempSize );
			my $cancel_msg = $obj->Cancel();
			if ($cancel_msg) {
				$err .= "</p><p><b>$str[73]:</b> $cancel_msg";
				}
			next Err;
			}

		$err = $obj->Merge();
		next Err if ($err);

		$err = $realms->setpagecount($realm, $total_records, 1);
		next Err if ($err);
		}
	return ($err, $total_records, $new_records, $updated_records, $deleted_records);
	}





sub update_database {
#db
	my ($realm, $ref_crawler_results) = @_;
	my ($total_records, $new_records, $updated_records, $deleted_records) = (0, 0, 0, 0);

	my $dbh = undef();
	my $sth = undef();

	my $err = '';
	Err: {

		my ($p_realm_data) = ();
		($err, $p_realm_data) = $realms->hashref($realm);
		next Err if ($err);

		my $realm_id = $$p_realm_data{'realm_id'};

		$err = &get_dbh(\$dbh);
		next Err if ($err);

		my $URL = '';

		my (@deletes, @updates, @meta_updates, @inserts) = ();

		unless ($sth = $dbh->prepare("SELECT url FROM $Rules{'sql: table name: addresses'} WHERE (url = ?)")) {
			$err = $str[45] . ' ' . $dbh->errstr();
			next Err;
			}

		while (defined($URL = each %$ref_crawler_results)) {
			my $ref_pagedata = $$ref_crawler_results{$URL};

			# does this URL exist in the database?
			unless ($sth->execute($URL)) {
				$err = $str[29] . ' ' . $sth->errstr();
				next Err;
				}

			my $b_exists = $sth->rows();

			# Records to be updated - only allow if exists

			if (($$ref_pagedata{'is_update'}) and ($b_exists)) {
				push(@meta_updates, $ref_pagedata);
				}

			elsif ($$ref_pagedata{'is_error'}) {

				if ($b_exists) {
					push(@deletes, $ref_pagedata);
					}
				else {
					# do nothin' - record failed, but don't exist in the index
					}
				}

			elsif ($b_exists) {
				push(@updates, $ref_pagedata);
				}
			else {
				push(@inserts, $ref_pagedata);
				}
			}
		$sth->finish();
		$sth = undef();

		# Execute the commands we've decided upon:

		if (@deletes) {

			unless ($sth = $dbh->prepare("DELETE FROM $Rules{'sql: table name: addresses'} WHERE url = ?")) {
				$err = $str[45] . ' ' . $dbh->errstr();
				next Err;
				}

			my $r_record = ();
			foreach $r_record (@deletes) {
				my $URL = $$r_record{'url'};
				unless ($sth->execute($URL)) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}
				unless ($$r_record{'sub status msg'}) {
					$$r_record{'sub status msg'} = $str[408];
					}
				$deleted_records++;
				}
			$sth->finish();
			$sth = undef();
			}

		if (@inserts) {
			unless ($sth = $dbh->prepare("INSERT INTO $Rules{'sql: table name: addresses'} (realm_id, url, lastindex, lastmodtime, dd, mm, yyyy, promote, size, title, description, keywords, text, links, um, ut, ud) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)")) {
				$err = $str[45] . ' ' . $dbh->errstr();
				next Err;
				}

			my $r_record = ();
			foreach $r_record (@inserts) {
				&compress_hash($r_record);
				my $URL = $$r_record{'url'};
				my $p = $$r_record{'promote'};
				unless ($sth->execute(
						$realm_id,
						$URL,
						time(),
						$$r_record{'lastmodtime'},
						$$r_record{'dd'},
						$$r_record{'mm'},
						$$r_record{'yyyy'},
						$$r_record{'promote'},
						$$r_record{'size'},
						$$r_record{'title'},
						$$r_record{'description'},
						$$r_record{'keywords'},
						$$r_record{'text'},
						$$r_record{'links'},
						$$r_record{'um'},
						$$r_record{'ut'},
						$$r_record{'ud'},
						)) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}

				unless ($$r_record{'sub status msg'}) {
					$$r_record{'sub status msg'} = $str[407];
					}
				$new_records++;
				}
			$sth->finish();
			$sth = undef();
			}


		if (@updates) {

			unless ($sth = $dbh->prepare("UPDATE $Rules{'sql: table name: addresses'} SET realm_id = ?, url = ?, lastindex = ?, lastmodtime = ?, dd = ?, mm = ?, yyyy = ?, promote = ?, size = ?, title = ?, description = ?, keywords = ?, text = ?, links = ?, um = ?, ut = ?, ud = ? WHERE url = ?")) {
				$err = $str[45] . ' ' . $dbh->errstr();
				next Err;
				}

			my $r_record = ();
			foreach $r_record (@updates) {
				&compress_hash($r_record);
				my $URL = $$r_record{'url'};
				unless ($sth->execute(
						$realm_id,
						$URL,
						time(),
						$$r_record{'lastmodtime'},
						$$r_record{'dd'},
						$$r_record{'mm'},
						$$r_record{'yyyy'},
						$$r_record{'promote'},
						$$r_record{'size'},
						$$r_record{'title'},
						$$r_record{'description'},
						$$r_record{'keywords'},
						$$r_record{'text'},
						$$r_record{'links'},
						$$r_record{'um'},
						$$r_record{'ut'},
						$$r_record{'ud'},
						$URL,
						)) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}

				unless ($$r_record{'sub status msg'}) {
					$$r_record{'sub status msg'} = $str[312];
					}
				$updated_records++;
				}
			$sth->finish();
			$sth = undef();
			}

		if (@meta_updates) {

			unless ($sth = $dbh->prepare("UPDATE $Rules{'sql: table name: addresses'} SET url = ?, lastindex = ?, lastmodtime = ?, dd = ?, mm = ?, yyyy = ?, promote = ?, size = ?, title = ?, description = ?, keywords = ?, um = ?, ut = ?, ud = ? WHERE url = ?")) {
				$err = $str[45] . ' ' . $dbh->errstr();
				next Err;
				}

			my $r_record = ();
			foreach $r_record (@meta_updates) {
				&compress_hash($r_record);
				my $URL = $$r_record{'url'};

				unless ($sth->execute(
						$$r_record{'new_url'},
						time(),
						$$r_record{'lastmodtime'},
						$$r_record{'dd'},
						$$r_record{'mm'},
						$$r_record{'yyyy'},
						$$r_record{'promote'},
						$$r_record{'size'},
						$$r_record{'title'},
						$$r_record{'description'},
						$$r_record{'keywords'},
						$$r_record{'um'},
						$$r_record{'ut'},
						$$r_record{'ud'},
						$URL,
						)) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}

				unless ($$r_record{'sub status msg'}) {
					$$r_record{'sub status msg'} = $str[312];
					}
				$updated_records++;
				}
			$sth->finish();
			$sth = undef();
			}
		$dbh->disconnect();
		$dbh = undef();

		$err = &get_dbh( \$dbh );
		next Err if ($err);

		unless ($sth = $dbh->prepare(
			"SELECT $Rules{'sql: table name: realms'}.name AS name, count(*) AS cnt FROM $Rules{'sql: table name: addresses'}
			LEFT JOIN $Rules{'sql: table name: realms'} ON
			$Rules{'sql: table name: addresses'}.realm_id=$Rules{'sql: table name: realms'}.realm_id
			GROUP BY $Rules{'sql: table name: realms'}.name")) {
			$err = $str[45] . ' ' . $dbh->errstr();
			next Err;
			}
		unless ($sth->execute()) {
			$err = $str[29] . ' ' . $sth->errstr();
			next Err;
			}
		my %pagecounts = ();
		my @data = ();
		while (@data = $sth->fetchrow_array()) {
			my ($name, $count) = @data;
			next unless ($name);
			$pagecounts{$name} = $count;
			}
		$sth->finish();
		$sth = undef();
		$dbh->disconnect();
		$dbh = undef();

		my ($name, $value) = ();
		while (($name, $value) = each %pagecounts) {
			$err = $realms->setpagecount($name, $value, 1);
			next Err if ($err);
			if ($realm eq $name) {
				$total_records = $value;
				}
			}
		}
	# clean up database connections if they're still active:
	$sth->finish() if ($sth);
	$dbh->disconnect() if ($dbh);
	return ($err, $total_records, $new_records, $updated_records, $deleted_records);
#/db
	}





sub update_realm {
	if ($Rules{'sql: enable'}) {
		return &update_database(@_);
		}
	else {
		return &update_file(@_);
		}
	}





sub query_realm {
	my ($realm, $query_pattern, $start_pos, $max_results, $ref_crawler_results) = @_;
	my $err = '';
	Err: {

		$err = &check_regex($query_pattern);
		next Err if ($err);

		my $p_realm_data = ();
		($err, $p_realm_data) = $realms->hashref($realm);
		next Err if ($err);

		if ($Rules{'sql: enable'}) {
			return &query_database(@_);
			}
		elsif ($$p_realm_data{'is_runtime'}) {
			return &query_runtime(@_);
			}
		else {
			return &query_file(@_);
			}
		}
	return $err;
	}





sub query_database {
#db
	my ($realm, $query_pattern, $start_pos, $max_results, $ref_crawler_results) = @_;

	my $dbh = undef();
	my $sth = undef();

	my $err = '';
	Err: {

		$err = &check_regex($query_pattern);
		next Err if ($err);


		my ($p_realm_data) = ();
		($err, $p_realm_data) = $realms->hashref($realm);
		next Err if ($err);

		$err = &get_dbh(\$dbh);
		next Err if ($err);

		my $query = "SELECT * FROM $Rules{'sql: table name: addresses'} WHERE (realm_id = $$p_realm_data{'realm_id'})";

		if ($query_pattern) {
			my $sql_pattern = $query_pattern;
			$sql_pattern =~ s!\.\*!\%!g;
			$query .= ' AND (url LIKE ' . $dbh->quote($sql_pattern) . ')';
			}

		$query .= " ORDER BY url LIMIT $start_pos,$max_results";

		unless ($sth = $dbh->prepare($query)) {
			$err = $str[45] . ' ' . $dbh->errstr();
			next Err;
			}
		unless ($sth->execute()) {
			$err = $str[29] . ' ' . $sth->errstr();
			next Err;
			}
		my $r_hash = ();
		while ($r_hash = $sth->fetchrow_hashref()) {
			my $URL = $$r_hash{'url'};
			$$ref_crawler_results{$URL} = $r_hash;
			}
		$sth->finish();
		$sth = undef();
		$dbh->disconnect();
		$dbh = undef();
		}
	$sth->finish() if ($sth);
	$dbh->disconnect if ($dbh);
	return $err;
#/db
	}





sub query_runtime {
	my ($realm, $query_pattern, $start_pos, $max_results, $ref_crawler_results) = @_;
	my $err = '';
	Err: {

		$err = &check_regex($query_pattern);
		next Err if ($err);


		my ($p_realm_data) = ();
		($err, $p_realm_data) = $realms->hashref($realm);
		next Err if ($err);

		my $fr = &fdse_filter_rules_new($p_realm_data);

		my $gf = &GetFiles_new();

		$err = $gf->create_file_list(
			'base_dir' => $$p_realm_data{'base_dir'},
			'base_url' => $$p_realm_data{'base_url'},
			'fr'    => \$fr,
			'tempfile' => "runtime.file_list. " . int(100 * rand()) . ".txt",
			'verbose' => 0,
			);
		next Err if ($err);

		if ($start_pos) {
			$gf->resume_file_position( $start_pos );
			}

		my $count = 0;

		my $record_err_msg = '';

		while ($count < $max_results) {
			my ($lastmodt, $size, $fullfile, $basefile, $url) = $gf->get_next_file();
			last unless ($url);
			my %pagedata = ();

			($record_err_msg,$url) = &pagedata_from_file( $fullfile, $url, \%pagedata, \$fr );
			if ($record_err_msg) {
			#	&ppstr(64, $record_err_msg );
				}
			else {
				$$ref_crawler_results{$url} = \%pagedata;
				$count++;
				}
			}
		$err = $gf->quit();
		}
	return $err;
	}





sub query_file {
	my ($realm, $query_pattern, $start_pos, $max_results, $ref_crawler_results) = @_;
	my $err = '';
	Err: {

		$err = &check_regex($query_pattern);
		next Err if ($err);

		my ($obj, $p_rhandle, $p_whandle) = ();

		my ($p_realm_data) = ();
		($err, $p_realm_data) = $realms->hashref($realm);
		next Err if ($err);

		my $file = $$p_realm_data{'file'};

		$obj = &LockFile_new();

		($err, $p_rhandle) = $obj->Read( $file );
		next Err if ($err);

		my $linecount = -1;
		while (defined($_ = readline($$p_rhandle))) {
			next if (($query_pattern) and (not m! u= $query_pattern t= !));
			$linecount++;
			next if ($linecount < $start_pos);
			last if ($linecount >= ($start_pos + $max_results));
			my ($is_valid, %pagedata) = &parse_text_record($_);
			if ($is_valid) {
				my $URL = $pagedata{'url'};
				$$ref_crawler_results{$URL} = \%pagedata;
				}
			}
		$err = $obj->Close();
		next Err if ($err);
		}
	return $err;
	}





sub get_remote_host {
	unless ($private{'remote_host'}) {
		$private{'remote_host'} = &query_env('REMOTE_HOST');
		if ((!$private{'remote_host'}) || ($private{'remote_host'} =~ m!^\d+\.\d+\.\d+\.\d+$!)) {
			if ($private{'visitor_ip_addr'} =~ m!^(\d+)\.(\d+)\.(\d+)\.(\d+)$!) {
				$private{'remote_host'} = (gethostbyaddr(pack('C4',$1,$2,$3,$4),2))[0] || $private{'visitor_ip_addr'};
				}
			}
		$private{'remote_host'} = lc($private{'remote_host'});
		}
	return $private{'remote_host'};
	}





sub get_absolute_url {
	my $URL = '';
	my $script_name = &query_env('SCRIPT_NAME','/');
	if ($ENV{'HTTP_HOST'}) {
		$URL = 'http://' . &query_env('HTTP_HOST') . $script_name;
		}
	elsif ($ENV{'SERVER_NAME'}) {
		$URL = 'http://' . &query_env('HTTP_HOST') . $script_name;
		}
	elsif ($ENV{'HTTP_REFERER'}) {
		$URL = &query_env('HTTP_REFERER');
		$URL =~ s!(\?|\$\|\#)(.*)!!o;
		}
	return $URL;
	}



sub print_AddURL_nav_header {
	my ($b_anon, $action) = @_;
	if ((not $b_anon) and (not $const{'is_cmd'}) and ($action ne 'rebuild')) {

print <<"EOM";

<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> / <a href="$const{'admin_url'}" target="_top">$str[443]</a> / $str[442]</b></p>

EOM
		}
	}





sub s_AddURL {
	my ($b_IsAnonAdd, $Realm, @addr_strings) = @_;


	my @AddressesToIndex = (); #changed 0054; support multi-line inputs
	local $_;
	foreach (@addr_strings) {
		foreach (split(m!\r|\n|\015|\012!s)) {
			my $addr = &Trim($_);
			next unless ($addr);
			if ($addr =~ m!^\w+://!) { # good; explicit proto
				}
			else {
				$addr = "http://$addr";
				}
			push( @AddressesToIndex, $addr );
			}
		}


	my $action = $FORM{'Action'} || '';

	&print_AddURL_nav_header( $b_IsAnonAdd, $action );

	my $p_realm_data = ();

	# hack
	$FORM{'UseTimeout'} = 1 unless (defined($FORM{'UseTimeout'}));


	my $err = '';
	Err: {


		if ($Realm) {
			($err, $p_realm_data) = $realms->hashref($Realm);
			next Err if ($err);
			}
		elsif (($FORM{'CreateSelectRealm'}) and (not $b_IsAnonAdd)) {
			my $url;
			($err, $url) = &uri_parse($FORM{'URL'});
			next Err if ($err);
			($err, $p_realm_data) = $realms->get_website_realm($url);
			next Err if ($err);
			}
		else {
			($err, $p_realm_data) = $realms->get_open_realm();
			next Err if ($err);
			}

		$FORM{'Realm'} = $$p_realm_data{'name'}; #0035 for benefit of &AdminVersion later


		if ($$p_realm_data{'type'} == 3) {
			if (length($$p_realm_data{'limit_pattern'})) {
				$FORM{'LimitPattern'} = $$p_realm_data{'limit_pattern'};
				}
			else {
				$FORM{'LimitPattern'} = '^' . quotemeta(&get_web_folder($$p_realm_data{'base_url'}));
				}
			}
		elsif ($$p_realm_data{'type'} == 5) {
			$err = &pstr(277, $$p_realm_data{'html_name'});
			next Err;
			}


		if (($b_IsAnonAdd) and ($Rules{'allowanonadd: require user email'})) {
			$err = &CheckEmail( $FORM{'EMAIL'} );
			next Err if ($err);
			}

		# Initialize:
		$FORM{'PagesDone'} = 0 unless ($FORM{'PagesDone'});
		my $NextLink = '';

		if (($action eq 'CrawlEntireSite') or ($FORM{'LimitPattern'})) {
			$FORM{'Batch'}++;
			print "\n<p><b>" . &pstr(186,&he($FORM{'LimitPattern'}), $$p_realm_data{'html_name'} ) . "</b><br />\n";
			&ppstr(189, $FORM{'Batch'} );
			print ' ';
			&ppstr(191, $FORM{'LimitIndexed'} || 0, $FORM{'LimitFailed'} || 0, $FORM{'LimitPending'} || 0 );
			print "</p>\n\n";
			}
		elsif ($action eq 'rebuild') {
			$FORM{'Batch'}++;
			print "\n<p><b>" . &pstr(185, $$p_realm_data{'html_name'} ) . "</b><br />\n";
			&ppstr(188, $FORM{'DaysPast'} ) if ($FORM{'DaysPast'});
			&ppstr(189, $FORM{'Batch'} );
			print ' ';
			&ppstr(191, $FORM{'LimitIndexed'}, $FORM{'LimitFailed'}, $FORM{'LimitPending'} );
			print "</p>\n\n";
			}
		else {
			print "\n<p><b>" . &pstr(187, $$p_realm_data{'html_name'} ) . "</b></p>\n\n";
			}

		$FORM{'PerBatch'} = $FORM{'PerBatch'} || $Rules{'crawler: max pages per batch'};
		$FORM{'PerBatch'} = $Rules{'crawler: max pages per batch'} if ($FORM{'PerBatch'} > $Rules{'crawler: max pages per batch'});


		my (@spidered_links, @crawled_pages, %crawler_results, %Response) = ();

		if (($FORM{'istimeout'}) and (not $b_IsAnonAdd)) {
			# shoot... they suffered a timeout...
			# Are the already only trying one at a time? if so, and if they have multiple addresses waiting, delete the first in the queue:

			&ppstr(53, $str[390] );

			if (($FORM{'PerBatch'} == 1) and ($#AddressesToIndex > 0)) {

				my $URL = $AddressesToIndex[0];

				&pppstr(389, $URL );
				@AddressesToIndex = (); #@AddressesToIndex[1..$#AddressesToIndex]; #changed 0054

				push(@crawled_pages, $URL);

				my $hURL = &he($URL);
				my %pagedata = (
					'is_error' => 1,
					'url' => $URL,
					'err' => 'operation timed out',
					'html listing' => "<dl><dt><b>1. $str[73]: $hURL</b></dt><dd>operation timed out</dd></dl>",
					'sub status msg' => '',
					'b_write_to_temp' => 0,
					);
				$crawler_results{$URL} = \%pagedata;
				}
			else {

				# reduce the workload by 50% if that would keep at least 1 URL
				my $test = int( $FORM{'PerBatch'} / 2 );
				if ($test > 0) {
					&pppstr(388, $FORM{'PerBatch'}, $test );
					$FORM{'PerBatch'} = $test;
					}
				}
			}
		elsif ($FORM{'PerBatch'} < $Rules{'crawler: max pages per batch'}) {
			&pppstr(387, $FORM{'PerBatch'}, $FORM{'PerBatch'} + 1 );
			$FORM{'PerBatch'}++;
			}

		if ((not $const{'is_cmd'}) and (($action eq 'rebuild') or ($action eq 'CrawlEntireSite'))) {

			$NextLink = &admin_link(
				'PerBatch' => $FORM{'PerBatch'},
				'Action' => $action,
				'LimitPattern' => $FORM{'LimitPattern'},
				'Batch' => $FORM{'Batch'},
				'DaysPast' => $FORM{'DaysPast'},
				'StartTime' => $FORM{'StartTime'},
				'Realm' => $$p_realm_data{'name'},
				);

			my $message = &pstr(536, "$const{'help_file'}1162.html" );
			$message =~ s!\"!\\\"!g; # escape quotes " for Javascript

print <<"EOM";

<script type="text/javascript">
<!--
function HandleUncontrolledExit() {
	if (!g_loaded) {
		// hmm.... we never made it to the end of this document... we are going to refresh this page after sleeping a bit...
		// probably the server timed out.
		window.setTimeout( "Reload();", 1000 * $Rules{'time interval between restarts'} );
		if ((document) && (document.all) && (document.all("script_output"))) {
			document.all("script_output").innerHTML += "<p>$message</p><p>To handle this error, this page will attempt to reload itself in $Rules{'time interval between restarts'} seconds.</p>";
			}
		}
	}
function Reload() {
	location.href = "$NextLink&PagesDone=$FORM{'PagesDone'}&istimeout=1";
	}
//-->
</script>

EOM


			&pppstr(192, "<a href=\"$NextLink&PagesDone=$FORM{'PagesDone'}&istimeout=1\">$str[193]</a>" );
			}

		print "<p>$str[194]</p>\n" unless ($const{'is_cmd'});

		my $crawler = &Crawler_new();
		my $fr = &fdse_filter_rules_new($p_realm_data);

		my $b_continue = 1;

		my $b_write_to_index = 1;
		my $b_write_to_temp = 0;

		my $default_approval_required = 0;

		if (($b_IsAnonAdd) and ($Rules{'require anon approval'})) {
			$default_approval_required = 1;
			$b_write_to_index = 0;
			$b_write_to_temp = 1;
			}


		my ($trailer, $URL) = ('', '', '', '', '', '', '');
		my ($pux_err,$source_url,$clean) = ();

		if ($Rules{'timeout'} < 12) {
			$Rules{'timeout'} += 10;
			}

		my $index_count = 0;
		my $no_network_errs = 0;

		my ($is_denied, $require_approval, $promote_val, $filter_err_msg, $no_update_on_redirect, $b_index_nofollow, $b_follow_noindex);

		$| = 1;

		ADDRESS: foreach (@AddressesToIndex) {

			my %pagedata = (
				'realm_id' => $$p_realm_data{'realm_id'},
				'url' => '',
				'final url' => '',
				'is_error' => 0,
				'err' => '',
				'require_approval' => $default_approval_required,
				'is_intermediate' => 0,
				'record' => '',
				'html listing' => '',
				'sub status msg' => '',
				'b_write_to_temp' => $b_write_to_temp, # set default
				);

			$b_continue = 1;

			$source_url = $URL = &Trim($_);

			CrawlErr: {

				if ((($index_count - $no_network_errs) >= $FORM{'PerBatch'}) or ($no_network_errs >= (5 * $FORM{'PerBatch'}))) {
					$trailer = "<dl><dt><b>$str[197]</b></dt><dd>";
					if ($b_IsAnonAdd) {
						$trailer .= "The crawler cannot index more than $FORM{'PerBatch'} links at one time.";
						}
					else {
						$trailer .= &pstr(196, $FORM{'PerBatch'}, &admin_link(
							'Action' => 'GeneralRules',
							'Edit' => 'Crawler: Max Pages Per Batch',
							));
						}
					$trailer .= "</dd></dl>\n";
					$b_continue = 0;
					next CrawlErr;
					}

				# check elapsed time - we budget 10 seconds for file operations, after crawling is done:
				my $elapsed_time = time - $private{'script_start_time'};
				if (($FORM{'UseTimeout'}) and ($Rules{'timeout'}) and ($elapsed_time > ($Rules{'timeout'} - 10))) {
					$trailer = "<dl><dt><b>$str[197]</b></dt><dd>";
					$trailer .= &pstr(198, $elapsed_time );
					$trailer .= "</dd></dl>\n";
					$b_continue = 0;
					next CrawlErr;
					}

				# apply input filter:
				$URL = &rewrite_url( 0, $URL );


				# the purpose of this call is to convert $URL to its "clean" form
				# we don't worry about error handling, because $crawler->webrequest will do that for us
				($pux_err, $clean) = &uri_parse($URL);
				if (not $pux_err) {
					$URL = $clean;
					}


				my $hURL = &he($URL);

				$index_count++;

				($is_denied, $require_approval, $promote_val, $filter_err_msg, $no_update_on_redirect, $b_index_nofollow, $b_follow_noindex) = $fr->check_filter_rules( $URL, '', 1);
				if ($is_denied) {
					$pagedata{'html listing'} = "<dl><dt><b>$index_count. $str[73]: $hURL</b></dt><dd>$str[73]: " . &he($filter_err_msg) . ".</dd></dl>";
					$pagedata{'is_error'} = 1;
					$pagedata{'err'} = &he($filter_err_msg);
					$no_network_errs++;
					next CrawlErr;
					}

				my $stime = time();
				if ($const{'is_cmd'}) {
					print STDERR "$URL... ";
					}
				else {
					print "-&gt; $str[195] '$hURL'... ";
					}
				%Response = $crawler->webrequest(
					'page' => $URL,
					'limit' => $FORM{'LimitPattern'},
					);
				my $duration = time() - $stime;
				if ($const{'is_cmd'}) {
					print STDERR "$duration sec\n";
					print STDERR "\t$str[73]: $Response{'err'}.\n" if ($Response{'err'});
					print STDERR "\t$str[202]: $Response{'final_url'}\n" if ($Response{'total_requests'} > 1);
					}
				else {
					&ppstr(204, $duration );
					print "<br />\n";
					}

				if ($no_update_on_redirect) {
					$pagedata{'url'} = $URL;
					}
				else {
					$pagedata{'url'} = $Response{'final_url'};
					}


				#changed 0054 - search.pending.txt rewrite bug fix
				if ($URL ne $source_url) {
					my $ref_redirects = $Response{'ref_redirects'};
					my @array = ($source_url, @$ref_redirects);
					@$ref_redirects = (); # zero anon array in mem
					$ref_redirects = 0; # zero refcount
					$Response{'ref_redirects'} = \@array;
					$Response{'total_requests'}++;
					}


				if ($Response{'total_requests'} > 1) {
					my $ref_redirects = $Response{'ref_redirects'};
					$pagedata{'redirects'} = &he("$str[202]: " . join(' => ', @$ref_redirects));

					# Log the fact that these URLs will redirect to other places:

					my @redirects = @$ref_redirects;

					if ($no_update_on_redirect) {

						#kill the first entry:
						my $len = scalar @redirects;
						@redirects = @redirects[1..($len-1)];
						}
					else {

						# kill the last entry:
						pop(@redirects);

						}

					foreach (@redirects) {
						next if (defined($crawler_results{$_}));
						my %pd = (
							'url' => $_,
							'is_error' => 1,
							'is_intermediate' => 1,
							'err' => $str[203],
							'require_approval' => $default_approval_required,
							);
						push(@crawled_pages, $_);
						$crawler_results{$_} = \%pd;
						}


					}
				$URL = $Response{'final_url'} unless ($no_update_on_redirect);
				$hURL = &he($URL);

				if ($Response{'err'}) {
					$pagedata{'html listing'} = "<dl><dt><b>$index_count. $str[73]: $hURL</b></dt><dd>$str[73]: $Response{'err'}.</dd></dl>";
					$pagedata{'is_error'} = 1;
					$pagedata{'err'} = $Response{'err'};
					next CrawlErr unless ($Response{'no_index_but_follow'}); # stick around a little longer if we wanna parse links
					}


				($is_denied, $require_approval, $promote_val, $filter_err_msg, $no_update_on_redirect, $b_index_nofollow, $b_follow_noindex) = $fr->check_filter_rules( $URL, $Response{'text'}, 0);
				if (($is_denied) or ($b_follow_noindex)) {
					if ($b_follow_noindex) {
						$Response{'no_index_but_follow'} = 1;
						$filter_err_msg = $str[87];
						}
					$pagedata{'html listing'} = "<dl><dt><b>$index_count. $str[73]: $hURL</b></dt><dd>$str[73]: " . &he($filter_err_msg) . ".</dd></dl>";
					$pagedata{'is_error'} = 1;
					$pagedata{'err'} = &he($filter_err_msg);
					next CrawlErr unless ($Response{'no_index_but_follow'}); # stick around a little longer if we wanna parse links
					}

				if ($b_index_nofollow) {
					next CrawlErr if ($Response{'no_index_but_follow'});
					$Response{'no_follow'} = 1;
					}

				if (($require_approval) or (($b_IsAnonAdd) and ($Rules{'require anon approval'}))) {

					$b_write_to_temp = 1;
					$pagedata{'b_write_to_temp'} = 1; # save this record to temp file only

					unless ($Response{'no_index_but_follow'}) {

						$pagedata{'require_approval'} = 1;
						$pagedata{'err'} = &he( $filter_err_msg );
						if ($b_IsAnonAdd) {
							$pagedata{'sub status msg'} = $str[199];
							}
						else {
							$pagedata{'sub status msg'} = "$str[498] - $filter_err_msg";
							}
						}
					}
				my $Text = $Response{'text'};

				if ($Response{'lastmodt'}) {
					$pagedata{'lastmodtime'} = $Response{'lastmodt'};
					}

				my $b_extract_links = $Response{'no_follow'} ? 0 : 1;
				&parse_html_ex($Text, $Response{'final_url'}, $b_extract_links, \@spidered_links, \%pagedata);

				$pagedata{'size'} = $Response{'size'} || length($Text);

				next CrawlErr if ($Response{'no_index_but_follow'}); # all we wanted was to populate \@spidered_links
				&compress_hash( \%pagedata );

				$pagedata{'promote'} = $promote_val;
				}
			last unless ($b_continue);
			push(@crawled_pages, $URL) unless (defined($crawler_results{$URL}));
			$crawler_results{$URL} = \%pagedata;
			}
		if ($const{'is_cmd'}) {
			print "\n$str[201]\n";
			}
		else {
			print "<p>$str[201]</p>\n";
			}

		$| = 0;


		# If we're a filefed realm, discard all the spidered links:
		if ($$p_realm_data{'type'} == 2) {
			@spidered_links = ();
			}
		elsif ($FORM{'LimitPattern'}) {
			my @new_links = ();
			my $pattern = $FORM{'LimitPattern'};
			foreach (@spidered_links) {
				next unless (m!$pattern!i);
				push(@new_links, $_);
				}
			@spidered_links = @new_links;
			}


		my (@LN, @LVN, @LVO, @LE) = ();
		my ($total_records, $new_records, $updated_records, $deleted_records) = ('', 0, 0, 0, 0);

		if ($b_write_to_index) {
			($err, $total_records, $new_records, $updated_records, $deleted_records) = &update_realm( $$p_realm_data{'name'}, \%crawler_results);
			next Err if ($err);
			$err = &SaveLinksToFileEx( $p_realm_data, \%crawler_results, \@spidered_links, \@LN, \@LVN, \@LVO, \@LE );
			next Err if ($err);
			}

		my $approval_count = 0;


		if ($b_write_to_temp) {

			my $user_email = $FORM{'EMAIL'} || '';

			my ($obj, $p_whandle) = ();
			$obj = &LockFile_new();
			($err, $p_whandle) = $obj->Append( $$p_realm_data{'file'} . '.need_approval' );
			next Err if ($err);

			foreach (@crawled_pages) {
				my $p_pagedata = $crawler_results{$_};
				next unless ($$p_pagedata{'require_approval'});

				my ($temp_err_msg, $text_record) = ('', '');

				unless ($$p_pagedata{'is_error'}) {
					($temp_err_msg, $text_record) = &text_record_from_hash($p_pagedata);
					if ($temp_err_msg) {
						&ppstr(64, $temp_err_msg );
						next;
						}
					# strip line breaks:
					$text_record =~ s!\n|\r|\015|\012!!g;
					$text_record =~ s!\|\|!\&#124;\&#124;!sg;
					}

				my $Record = join('||', $private{'script_start_time'}, &get_remote_host(), $$p_pagedata{'err'}, $$p_pagedata{'is_error'}, $$p_pagedata{'url'}, $text_record, $user_email);
				print { $$p_whandle } $Record . "\n";
				$approval_count++;
				}

			$err = $obj->FinishAppend();
			next Err if ($err);
			}

		if (($b_IsAnonAdd) and ($Rules{'allowanonadd: log'})) {
			my $user_email = $FORM{'EMAIL'} || '';
			my ($obj, $p_whandle) = ();
			$obj = &LockFile_new();
			($err, $p_whandle) = $obj->Append( 'submissions.csv' );
			next Err if ($err);

			# write schema as first line
			unless (-s 'submissions.csv') {
				print { $$p_whandle } "perl_time,human_time,remote_host,remote_addr,visitor_email,URL,realm,error,\n";
				}

			foreach (@crawled_pages) {
				my $p_pagedata = $crawler_results{$_};

				my $record = '';

				my $field;
				foreach $field (

					$private{'script_start_time'},
					&FormatDateTime( $private{'script_start_time'}, $Rules{'ui: date format'} ),
					&get_remote_host(),
					$private{'visitor_ip_addr'},
					$user_email,
					$$p_pagedata{'url'},
					$$p_realm_data{'name'},
					$$p_pagedata{'err'},

					) {
					if ($field =~ m!\"|\015|\012!) {
						$field =~ s!\"!""!sg;
						$field = qq!"$field"!;
						}
					$record .= "$field,";
					}

				print { $$p_whandle } "$record\n";
				}
			$err = $obj->FinishAppend();
			next Err if ($err);
			}


		if (($b_IsAnonAdd) and ($Rules{'allowanonadd: notify admin'})) {

			MailAdmin: {

				last MailAdmin unless (($Rules{'admin notify: smtp server'}) or ($Rules{'admin notify: sendmail program'}));
				last MailAdmin unless ($Rules{'admin notify: email address'});

				my $URL = &get_absolute_url();

				my $mail_message = '';

				$mail_message .= "$str[205]\015\012\015\012";

				$mail_message .= "Visitor Information:\015\012" . '-' x 20 . "\015\012";

				$mail_message .= ' ' x (10 - length($str[206])) . $str[206] . ": $FORM{'EMAIL'}\015\012";
				$mail_message .= ' ' x (10 - length($str[207])) . $str[207] . ": $private{'visitor_ip_addr'}\015\012";
				$mail_message .= ' ' x (10 - length($str[85])) . $str[85] . ": " . &get_remote_host() . "\015\012";

				$mail_message .= "\015\012";
				$mail_message .= "Submitted Page Information:\015\012";
				$mail_message .= '-' x length("Submitted Page Information:") . "\015\012";

				$mail_message .= ' ' x (10 - length($str[531])) . $str[531] . ": $$p_realm_data{'name'}\015\012";
				$mail_message .= "\015\012";

				my $LastURL = '';
				foreach (@crawled_pages) {
					my $p_pagedata = $crawler_results{$_};
					$mail_message .= ' ' x (10 - length($str[74])) . $str[74] . ": $$p_pagedata{'url'}\015\012";

					if ($$p_pagedata{'err'}) {
						$mail_message .= ' ' x (10 - length($str[73])) . $str[73] . ": $$p_pagedata{'err'}\015\012";
						}
					elsif ($$p_pagedata{'require_approval'}) {
						$mail_message .= "          - $str[498]\015\012";
						}
					else {
						$mail_message .= "          - OK\015\012";
						}



					$mail_message .= "\015\012";

					$LastURL = $$p_pagedata{'url'};
					}

				$mail_message .= "\015\012" . '-' x 78 . "\015\012\015\012";

				if ($approval_count) {
					$mail_message .= "$str[498]:\n\t$URL?ApproveRealm=$$p_realm_data{'url_name'}";
					}
				else {
					$mail_message .= $str[381];
					}

$mail_message .= <<"EOM";


Fluid Dynamics Search Engine
	$URL?Mode=Admin

-----------------------------------------------------------------------------

EOM

				foreach (sort keys %FORM) {
					next if (m!^(Mode|Match|PagesDone|PerBatch|EMAIL|Realm|URL|Terms|UseTimeout|maxhits|p:pm|q|terms)$!);
					$mail_message .= "$_: $FORM{$_}\015\012\015\012";
					}

				# Use end-user-address *if* it is valid:
				my $from_addr = $Rules{'admin notify: email address'};
				unless (&CheckEmail( $FORM{'EMAIL'} )) {
					$from_addr = $FORM{'EMAIL'};
					}


				&SendMailEx(
					'handler_order' => '12',
					'to'   => $Rules{'admin notify: email address'},
					'to name' => 'FDSE Administrator',
					'from'  => $from_addr,
					'host'  => $Rules{'admin notify: smtp server'},
					'pipeto' => $Rules{'admin notify: sendmail program'},
					'p_nc_cache' => $const{'p_nc_cache'},
					'use standard io' => $Rules{'use standard io'},
					'subject' => &pstr(209, $LastURL ),
					'message' => $mail_message,
					);

				}

			}



		my $i = 0;
		ADDRESS: foreach (@crawled_pages) {
			last if ($const{'is_cmd'});
			my $p_pagedata = $crawler_results{$_};
			next if ($$p_pagedata{'is_intermediate'});
			$i++;
			if ($$p_pagedata{'html listing'}) {
				print $$p_pagedata{'html listing'};
				}
			elsif ($b_IsAnonAdd) {
				print &StandardVersion(0, 'rank' => $i, %$p_pagedata);
				}
			else {
				print &AdminVersion('rank' => $i, %$p_pagedata);
				}
			print "<p>[ " . $$p_pagedata{'redirects'} . " ]</p>\n" if ($$p_pagedata{'redirects'});
			print "<p>[ " . $$p_pagedata{'sub status msg'} . " ]</p>\n" if ($$p_pagedata{'sub status msg'});
			}

		print $trailer;

		if ($b_write_to_index) {
			&pppstr(289, $total_records, $$p_realm_data{'html_name'}, $new_records, $updated_records, $deleted_records );
			}


		last Err if ($b_IsAnonAdd);
		last Err if ($const{'is_cmd'});

		if (($action eq 'rebuild') or ($action eq 'CrawlEntireSite')) {

			$NextLink .= "&PagesDone=" . ($FORM{'PagesDone'} + $index_count);

			my $advice = &pstr(211, $Rules{'time interval between restarts'}, $NextLink );

print <<"EOM";

<meta http-equiv="refresh" content="$Rules{'time interval between restarts'};URL=$NextLink" />
<p><b>$str[210]:</b></p>
<blockquote>
	<p>$advice</p>
</blockquote>

EOM

			last Err;
			}






		#changed 0054 -- allow website, file-fed, filtered, and open realms to use Add New URL form
		my $count = 0;
		my $ChooseRealmLine = '';

		my $p_data;
		foreach $p_data ($realms->listrealms('all')) {
			next if (($$p_data{'type'} == 4) or ($$p_data{'type'} == 5));
			$ChooseRealmLine .= qq!<option value="$$p_data{'html_name'}">$$p_data{'html_name'}</option>\n!;
			$count++;
			}



		my $formtag = $const{'AdminForm'};
		$formtag =~ s! name="?F1"?!!sg;

		my $input = '<input name="URL" size="40" value="http://" />';
		if ($Rules{'multi-line add-url form - visitors'}) {
			$input = '<textarea name="URL" rows="3" cols="40" style="wrap:soft">http://</textarea>';
			}


print <<"EOM";

<p><b>$str[172]</b></p>
<blockquote>

	<p>$str[291]</p>
	$formtag
	<input type="hidden" name="Action" value="AddURL" />
	<table border="0">
	<tr>
		<td align="right"><b>$str[74]:</b></td>
		<td>$input</td>
	</tr>

EOM

my %defaults = (
	'Realm' => $Realm,
	);

print &SetDefaults(<<"EOM", \%defaults);

	<tr>
		<td align="right"><b>$str[531]:</b></td>
		<td><select name="Realm">$ChooseRealmLine</select></td>
	</tr>

EOM

print <<"EOM";

	<tr>
		<td><br /></td>
		<td><input type="submit" class="submit" value="$str[172]" /></td>
	</tr>
	</table>

	</form>
</blockquote>

EOM

		my $LinkCount = $#LN + $#LVO + $#LVN + $#LE + 4;

		unless ($LinkCount) {
			print "<p>$str[213]</p>\n";
			last Err;
			}

print <<"EOM";

		<p><b>$str[214]</b></p>
		<blockquote>

$const{'AdminForm'}
<input type="hidden" name="Action" value="AddURL" />
<input type="hidden" name="Realm" value="$$p_realm_data{'name'}" />

		<p>$str[215]</p>

		<blockquote>

EOM
		if ($FORM{'LimitPattern'}) {
			my $hval = &he($FORM{'LimitPattern'});
			print qq!<input type="hidden" name="LimitPattern" value="$hval" />\n!;
			}

print <<"EOM";

<input type="submit" class="submit" value="$str[374]" />
<script type="text/javascript">
<!--
function ClearAll(state) {
	if ((document) && (document.forms[1])) {
EOM
for (1..$LinkCount) {
	print "document.forms[1].A$_.checked = state;\n";
	}
print <<"EOM";
		}
	}
if ((document) && (document.forms[1])) {
	document.write('<font size="-1">[ <a href="javascript:ClearAll(false)">$str[397]</a> ] [ <a href="javascript:ClearAll(true)">$str[398]</a> ]</font>');
	}
//-->
</script>
</blockquote>
EOM

		$LinkCount = 1;

		if (@LN) {
			print "<p>$str[216]</p>\n";
			foreach (sort @LN) {
				my $html_url = &he( $_ );
				print qq!<input type="checkbox" name="A$LinkCount" value="$html_url" checked="checked" /> $html_url<br />\n!;
				$LinkCount++;
				}
			}

		if (@LE) {
			print "<p>$str[217]</p>\n";
			foreach (sort @LE) {
				my $html_url = &he( $_ );
				print qq!<input type="checkbox" name="A$LinkCount" value="$html_url" /> $html_url<br />\n!;
				$LinkCount++;
				}
			}
		if (@LVO) {
			&pppstr(218, $Rules{'crawler: days til refresh'} );
			foreach (sort @LVO) {
				my $html_url = &he( $_ );
				print qq!<input type="checkbox" name="A$LinkCount" value="$html_url" checked="checked" /> $html_url<br />\n!;
				$LinkCount++;
				}
			}
		if (@LVN) {
			&pppstr(219, $Rules{'crawler: days til refresh'} );
			foreach (sort @LVN) {
				my $html_url = &he( $_ );
				print qq!<input type="checkbox" name="A$LinkCount" value="$html_url" /> $html_url<br />\n!;
				$LinkCount++;
				}
			}

		print "</form></blockquote>";

		last Err;
		}
	return $err;
	}





sub admin_link {
	local $_;
	my (%params) = @_;
	my $link = $const{'admin_url'};
	my ($name, $value) = ();
	while (($name, $value) = each %params) {
		$link .= '&' . &url_encode($name) . '=' . &url_encode($value);
		}
	return $link;
	}





sub SaveLinksToFileEx {
	my ($p_realm_data, $ref_crawler_results, $ref_spidered_links, $ref_links_new, $ref_links_visited_fresh, $ref_links_visited_old, $ref_links_error) = @_;
	my $err = '';
	Err: {

		unless (($p_realm_data) and ('HASH' eq ref($p_realm_data))) {
			$err = &pstr(21, 'p_realm_data' );
			next Err;
			}

		# ONLY save those code-0 links if we're a website realm with crawler discovery or we're LimitEntireSite mode:
		my $b_save_waiting_links = 0;
		if (($$p_realm_data{'type'} == 3) or (($FORM{'LimitPattern'}) and ($FORM{'Action'}) and ($FORM{'Action'} eq 'CrawlEntireSite'))) {
			$b_save_waiting_links = 1;
			}
		elsif ($$p_realm_data{'type'} == 6) {
			$b_save_waiting_links = 1;
			}


		my $url_realm = $$p_realm_data{'url_name'};

		my %return_status = ();
		my $b_return_status_info = 0;
		if (($ref_spidered_links) and ($ref_links_new) and ($ref_links_visited_fresh) and ($ref_links_visited_old) and ($ref_links_error)) {
			$b_return_status_info = 1;
			}


		my @Global = ();

		# Take all pages indexed during this round and assign them a value of the
		# current time if they were successful and a 2 if they failed.

		my %written = ();

		my ($name, $value);
		while (($name, $value) = each %$ref_crawler_results) {
			if ($$value{'is_error'}) {
				push( @Global, "$name $url_realm 2" );
				}
			else {
				push( @Global, "$name $url_realm $private{'script_start_time'}" );
				}
			$written{$name} = 1;
			}

		if (($ref_spidered_links) and ('ARRAY' eq ref($ref_spidered_links))) {

			# Add all saved links to this array with a 0 numeric index. Also create an
			# associative array of them for later comparisons:

			foreach (@$ref_spidered_links) {
				next if ($written{$_});
				push( @Global, "$_ $url_realm 0" );
				$return_status{$_} = 0;
				$written{$_} = 1;
				}
			}

		last Err unless (@Global); # don't bother if we have nothin to work with...

		my ($obj, $p_rhandle, $p_whandle) = ();

		$obj = &LockFile_new(
			'create_if_needed' => 1,
			);

		($err, $p_rhandle, $p_whandle) = $obj->ReadWrite( 'search.pending.txt' );
		next Err if ($err);


		my $b_compare = 1;

		my $maxi = $#Global;
		@Global = sort @Global;
		my $i = 0;

		my ($insert_url, $insert_realm, $insert_code) = ('','',0);

		if ($Global[$i] =~ m!^(.+) (\S+) (\d+)$!) {
			($insert_url, $insert_realm, $insert_code) = ($1, $2, $3);
			}

		my ($last_url, $last_realm, $last_code) = ('', '', 0);

		my ($cur_url, $cur_realm, $cur_code) = ('', '', 0);

		my $b_get_next_line = 1;

		my $file_done = 0;

		while (1) {
			if ($b_get_next_line) {
				if (defined($_ = readline($$p_rhandle))) {
					next unless (m!^(.+) (\S+) (\d+)$!);
					($cur_url, $cur_realm, $cur_code) = ($1, $2, $3);
					}
				elsif ($i <= $maxi) {
					$file_done = 1;
					$cur_url = 'z';
					$b_get_next_line = 0;
					}
				else {
					last;
					}
				}
			else {
				$b_get_next_line = 1;
				# unless the incoming records explicitly reset it to 0
				}

			# If we are different than our predecessors, we print out predecessors and take on their role. We are now pred and will be compared to new input

			# If we are the same, then we resolve which us of is superior, and loop next, without printing

			# This is done to weed out multiple sequential duplicates in the pending file

			if (($file_done) or ("$last_url $last_realm" ne "$cur_url $cur_realm")) {

				if ($b_compare) {

					# Right before we print, we check whether we should insert the current insert record.
					# If the current record falls before this one, we insert clean
					# If the current insert record is equal to this one, we fight it out and winner writes

					if ("$insert_url $insert_realm" lt "$last_url $last_realm") {
						# okay, insert clean:
						print { $$p_whandle } "$insert_url $insert_realm $insert_code\n" if (($b_save_waiting_links) or ($insert_code));
						$i++;
						if ($i > $maxi) {
							$b_get_next_line = 1;
							$b_compare = 0;
							}
						else {
							$Global[$i] =~ m!^(.+) (\S+) (\d+)$!;
							($insert_url, $insert_realm, $insert_code) = ($1, $2, $3);
							$b_get_next_line = 0; # give the next guy in @Global a chance
							next;
							}
						}
					elsif ("$insert_url $insert_realm" eq "$last_url $last_realm") {
						$last_code = $insert_code if (($insert_code > $last_code) or ($insert_code == 2));
						$return_status{$insert_url} = $last_code if (defined($return_status{$insert_url}));
						$i++;
						if ($i > $maxi) {
							$b_get_next_line = 1;
							$b_compare = 0;
							}
						else {
							$Global[$i] =~ m!^(.+) (\S+) (\d+)$!;
							($insert_url, $insert_realm, $insert_code) = ($1, $2, $3);
							$b_get_next_line = 0; # give the next guy in @Global a chance
							next;
							}

						}
					}


				print { $$p_whandle } "$last_url $last_realm $last_code\n" if (($last_url) and ($last_url ne 'z'));
				($last_url, $last_realm, $last_code) = ($cur_url, $cur_realm, $cur_code);

				}
			else {
				$last_code = $cur_code if ($cur_code > $last_code);
				}
			$b_get_next_line = 1;
			} # end loop
		print { $$p_whandle } "$last_url $last_realm $last_code\n" if (($last_url) and ($last_url ne 'z'));

		$err = $obj->Merge();
		next Err if ($err);

		last Err unless ($b_return_status_info);

		my $cut_age = $private{'script_start_time'} - (86400 * $Rules{'crawler: days til refresh'});

		my $url;
		while (($url, $value) = each %return_status) {
			if ($value == 0) {
				push( @$ref_links_new, $url );
				}
			elsif ($value == 2) {
				push( @$ref_links_error, $url );
				}
			elsif ($value < $cut_age) {
				push( @$ref_links_visited_old, $url );
				}
			else {
				push( @$ref_links_visited_fresh, $url );
				}
			}
		}
	return $err;
	}





sub get_age_str {
	my ($age) = @_;
	my $age_str = '';
	$age += 59; # round up
	if ($age > (2 * 86400)) {
		$age_str = &pstr(220, int($age / 86400) );
		}
	elsif ($age > (100 * 60)) {
		$age_str = &pstr(222, int($age / 3600) );
		}
	else {
		$age_str = &pstr(221, int($age / 60) );
		}
	$age_str;
	}





sub realm_interact {
	my ($p_realm_data, $sql_enable, $p_code) = @_;
	%$p_code = ();

	$const{'embedded_err_msg'} = '';

	if ($sql_enable) {
#db
# Start-up routines:

$$p_code{'init'} = $$p_code{'resume'} = <<'EOM';

	RI: {
		$const{'embedded_err_msg'} = &get_dbh( \$dbh );
		next RI if ($const{'embedded_err_msg'});

		my $query = "SELECT url, lastmodtime FROM $Rules{'sql: table name: addresses'} WHERE realm_id = $$p_realm_data{'realm_id'} ORDER BY url";
		unless ($sth_getnext = $dbh->prepare($query)) {
			$const{'embedded_err_msg'} = $str[45] . ' (' . $query . ') ' . $dbh->errstr();
			next RI;
			}

		unless ($sth_getnext->execute()) {
			$const{'embedded_err_msg'} = $str[29] . ' (' . $query . ') ' . $sth_getnext->errstr();
			next RI;
			}

		unless ($sth_insert = $dbh->prepare("INSERT INTO $Rules{'sql: table name: addresses'} (realm_id, url, lastindex, lastmodtime, dd, mm, yyyy, promote, size, title, description, keywords, text, links, um, ut, ud) VALUES ($$p_realm_data{'realm_id'}, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)")) {
			$const{'embedded_err_msg'} = $str[45] . ' ' . $dbh->errstr();
			next RI;
			}

		unless ($sth_update = $dbh->prepare("UPDATE $Rules{'sql: table name: addresses'} SET realm_id = $$p_realm_data{'realm_id'}, url = ?, lastindex = ?, lastmodtime = ?, dd = ?, mm = ?, yyyy = ?, promote = ?, size = ?, title = ?, description = ?, keywords = ?, text = ?, links = ?, um = ?, ut = ?, ud = ? WHERE url = ?")) {
			$const{'embedded_err_msg'} = $str[45] . ' ' . $dbh->errstr();
			next RI;
			}

		unless ($sth_delete = $dbh->prepare("DELETE FROM $Rules{'sql: table name: addresses'} WHERE url = ?")) {
			$const{'embedded_err_msg'} = $str[45] . ' ' . $dbh->errstr();
			next RI;
			}

		}
EOM

$$p_code{'resume'} .= <<'EOM';

	for (0..$i_line) {
		$sth_getnext->fetchrow_array();
		}

EOM


# Shut-down routines:

$$p_code{'suspend'} = $$p_code{'abort'} = $$p_code{'finish'} = <<'EOM';

	$sth_insert->finish();
	$sth_insert = undef();
	$sth_update->finish();
	$sth_update = undef();
	$sth_delete->finish();
	$sth_delete = undef();
	$sth_getnext->finish();
	$sth_getnext = undef();
	$dbh->disconnect();
	$dbh = undef();

EOM

$$p_code{'abort'} .= <<'EOM';

	# Not possible in SQL since we don't have a temp DB
	print "<p><b>Warning:</b> not able to cancel SQL update.</p>\n";

	$sth_insert->finish();
	$sth_insert = undef();
	$sth_update->finish();
	$sth_update = undef();
	$sth_delete->finish();
	$sth_delete = undef();
	$sth_getnext->finish();
	$sth_getnext = undef();
	$dbh->disconnect();
	$dbh = undef();

EOM


# Getnext routine:

$$p_code{'get_next'} = <<'EOM';

	unless ($index_is_done) {
		my @data = ();
		if (@data = $sth_getnext->fetchrow_array()) {
			($i_url, $i_lastmodt) = @data;
			$i_line++;
			}
		else {
			$index_is_done = 1;
			}
		}

EOM



# Read/write operations

$$p_code{'update'} = <<'EOM';

	unless ($sth_update->execute(
		$pagedata{'url'},
		time(),
		$pagedata{'lastmodtime'},
		$pagedata{'dd'},
		$pagedata{'mm'},
		$pagedata{'yyyy'},
		$pagedata{'promote'},
		$pagedata{'size'},
		$pagedata{'title'},
		$pagedata{'description'},
		$pagedata{'keywords'},
		$pagedata{'text'},
		$pagedata{'links'},
		$pagedata{'um'},
		$pagedata{'ut'},
		$pagedata{'ud'},
		$pagedata{'url'},
		)) {
		$const{'embedded_err_msg'} = $str[29] . ' ' . $sth_update->errstr();
		}
	else {
		$pagecount++;
		}

EOM

$$p_code{'insert'} = <<'EOM';

	unless ($sth_insert->execute(
		$pagedata{'url'},
		time(),
		$pagedata{'lastmodtime'},
		$pagedata{'dd'},
		$pagedata{'mm'},
		$pagedata{'yyyy'},
		$pagedata{'promote'},
		$pagedata{'size'},
		$pagedata{'title'},
		$pagedata{'description'},
		$pagedata{'keywords'},
		$pagedata{'text'},
		$pagedata{'links'},
		$pagedata{'um'},
		$pagedata{'ut'},
		$pagedata{'ud'},
		)) {
		$const{'embedded_err_msg'} = $str[29] . ' ' . $sth_insert->errstr();
		}
	else {
		$pagecount++;
		}

EOM

$$p_code{'delete'} = <<'EOM';

	unless ($sth_delete->execute( $i_url )) {
		$const{'embedded_err_msg'} = $str[29] . ' - ' . $sth_delete->errstr();
		}

EOM

$$p_code{'preserve'} = <<'EOM';

	$pagecount++;

	# Do nothing for SQL

EOM







#/db

		}
	else {

# Start-up routines:

$$p_code{'init'} = <<'EOM';


		$obji = &LockFile_new();
		($const{'embedded_err_msg'}, $p_rhandlei, $p_whandlei) = $obji->ReadWrite( $$p_realm_data{'file'} );

EOM

$$p_code{'resume'} = <<'EOM';

		$obji = &LockFile_new();
		($const{'embedded_err_msg'}, $p_rhandlei, $p_whandlei) = $obji->Resume( $$p_realm_data{'file'} );

EOM


# Shut-down routines:

$$p_code{'finish'} = <<'EOM';

		$const{'embedded_err_msg'} = $obji->Merge();

EOM

$$p_code{'abort'} = <<'EOM';

		$const{'embedded_err_msg'} = $obji->Cancel();

EOM

$$p_code{'suspend'} = <<'EOM';

		$const{'embedded_err_msg'} = $obji->Suspend();

EOM





# Getnext code:

$$p_code{'get_next'} = <<'EOM';

	unless ($index_is_done) {
		while (1) {
			unless (defined($_ = readline($$p_rhandlei))) {
				$index_is_done = 1;
				last;
				}
			if (m!^(\d+) (\d+) (\d+).+?u= (.*?) t=!) {
				($i_url, $i_lastmodt) = ($4, $2);
				$i_line++;
				$record = $_;
				last;
				}
			}
		}

EOM

$$p_code{'insert'} = $$p_code{'update'} = <<'EOM';

	my ($xrecord_err, $xrecord) = &text_record_from_hash( \%pagedata );
	if ($xrecord_err) {
		&ppstr(64,$xrecord_err);
		}
	else {
		unless (print { $$p_whandlei } $xrecord) {
			$write_err = &pstr(43, $obji->{'wname'}, $! );
			}
		$pagecount++;
		}

EOM

$$p_code{'delete'} = <<'EOM';

	# do nothing

EOM

$$p_code{'preserve'} = <<'EOM';

	unless (print { $$p_whandlei } $record) {
		$write_err = &pstr(43, $obji->{'wname'}, $! );
		}
	$pagecount++;

EOM

		}
	}





sub UpdateIndex {
	my ($p_realm_data) = @_;
	my $err = '';
	my $is_complete = 0;

	my $dbh = undef();
	my $sth_getnext = undef();
	my $sth_insert = undef();
	my $sth_update = undef();
	my $sth_delete = undef();

	Err: {

		local $_;

		# Create a list of all files and their last modified times:

		my $i_line = 0;
		my $a_line = 0;

		my $fr = &fdse_filter_rules_new($p_realm_data);

		my $gf = &GetFiles_new();

		$err = $gf->create_file_list(
			'base_dir' => $$p_realm_data{'base_dir'},
			'base_url' => $$p_realm_data{'base_url'},
			'fr'    => \$fr,
			'tempfile' => $$p_realm_data{'file'} . ".temp_file_list.txt",
			'verbose' => 1,
			);
		&pppstr(224, $gf->{'count'}, $$p_realm_data{'base_dir'} );

		# Open the realm index file for purposes of looping through it and re-writing it:

		my %code = ();
		&realm_interact( $p_realm_data, $Rules{'sql: enable'}, \%code );
		my ($obji, $p_rhandlei, $p_whandlei, $record, $record_err, $pagecount, $write_err) = ();

		eval $code{'init'};
		die $@ if $@;
		if ($const{'embedded_err_msg'}) {
			$err = $const{'embedded_err_msg'};
			next Err;
			}

		# Okay, proceed through the double parallel loop

		my ($a_url, $a_file, $a_lastmodt) = ('', '', 0);
		my ($i_url, $i_lastmodt) = ('', 0);

		my $index_is_done = 0;

		my $getnext = 2;

		$| = 1;

		my ($size, $basefile) = ();

		my $i_url_prev = '';

		my %crawler_results = ();
		my %valid = (
			'is_error' => 0,
			);
		my %invalid = (
			'is_error' => 1,
			);


# $a_url and $a_lastmodt refer to the *actual* sorted files in the folder

# $i_url and $i_lastmodt refer to the contents of the current index file, which may be out-of-date


		DREAD: while (1) {
			last if ($write_err);
			my %pagedata = ();

			if ($getnext == 2) {
				($a_lastmodt, $size, $a_file, $basefile, $a_url) = $gf->get_next_file();
				last DREAD unless ($a_url);
				$a_line++;
				$i_url_prev = $i_url;
				eval $code{'get_next'};
				die $@ if $@;
				if ($const{'embedded_err_msg'}) {
					$err = $const{'embedded_err_msg'};
					next Err;
					}
				}
			elsif ($getnext == 1) {
				($a_lastmodt, $size, $a_file, $basefile, $a_url) = $gf->get_next_file();
				last DREAD unless ($a_url);
				$a_line++;
				}
			elsif ($getnext == 0) {
				$i_url_prev = $i_url;
				eval $code{'get_next'};
				die $@ if $@;
				if ($const{'embedded_err_msg'}) {
					$err = $const{'embedded_err_msg'};
					next Err;
					}
				}

			if ($i_url lt $i_url_prev) { # fatal/die - alpha sort lost
				eval $code{'cancel'};
				die $@ if $@;
				if ($const{'embedded_err_msg'}) {
					$err = $const{'embedded_err_msg'};
					next Err;
					}
				$err = $str[225] . ' (' . &he($i_url) . ' versus previous ' . &he($i_url_prev) . ')';
				next Err;
				}

			my $action = '';

			if ($a_url eq $i_url) {
				if ($a_lastmodt > $i_lastmodt) {
					$record_err = (&pagedata_from_file( $a_file, $a_url, \%pagedata, \$fr ))[0];
					if ($record_err) {
						&ppstr(64, &he($a_url) . ' - ' . $record_err);
						print "\n\n";
						$action = 'delete';
						}
					else {
						&pppstr(226, $a_url );
						$pagedata{'lastindex'} = $private{'script_start_time'};
						$action = 'update';
						}
					}
				else {
					$action = 'preserve';
					}
				$getnext = 2;
				}
			elsif (($a_url lt $i_url) or ($index_is_done)) {
				$getnext = 1;
				my $index_url = '';
				($record_err, $index_url) = &pagedata_from_file( $a_file, $a_url, \%pagedata, \$fr );
				if ($record_err) {
					&ppstr(64, &he($a_url) . ' - ' . $record_err);
					print "\n\n";
					}
				else {
					&pppstr(227, &he($a_url) );
					$pagedata{'lastindex'} = $private{'script_start_time'};
					$action = 'insert';
					$crawler_results{$index_url} = \%valid;
					}
				}
			elsif ($a_url gt $i_url) {
				&pppstr(228, &he($i_url) );
				$getnext = 0;
				$action = 'delete';
				$crawler_results{$a_url} = \%invalid;
				}

			if ($action) {
				eval $code{$action};
				die $@ if $@;
				if ($const{'embedded_err_msg'}) {
					$err = $const{'embedded_err_msg'};
					next Err;
					}
				}
			}

		$err = $gf->quit(1);
		next Err if ($err);

		$is_complete = 1;

		if ($write_err) {
			&ppstr(64, $write_err );
			eval $code{'abort'};
			die $@ if $@;
			if ($const{'embedded_err_msg'}) {
				$err = $const{'embedded_err_msg'};
				next Err;
				}
			last Err;
			}

		eval $code{'finish'};
		die $@ if $@;
		if ($const{'embedded_err_msg'}) {
			$err = $const{'embedded_err_msg'};
			next Err;
			}

		$err = &SaveLinksToFileEx( $p_realm_data, \%crawler_results );
		next Err if ($err);

		$err = $realms->setpagecount( $$p_realm_data{'name'}, $pagecount, 1 );
		next Err if ($err);

		&ppstr(174, $str[229] );

		last Err;
		}
	$sth_getnext->finish() if ($sth_getnext);
	$sth_insert->finish() if ($sth_insert);
	$sth_update->finish() if ($sth_update);
	$sth_delete->finish() if ($sth_delete);
	$dbh->disconnect() if ($dbh);
	return ($err, $is_complete);
	}





sub BuildIndex {
	my ($p_realm_data) = @_;
	my $is_complete = 0;

	my $dbh = undef();
	my $sth_getnext = undef();
	my $sth_insert = undef();
	my $sth_update = undef();
	my $sth_delete = undef();

	my $err = '';
	Err: {
		# hack
		$FORM{'UseTimeout'} = 1 unless (defined($FORM{'UseTimeout'}));

		my $start_pos = 0;
		if (($FORM{'StartFile'}) and ($FORM{'StartFile'} =~ m!^\d+$!)) {
			$start_pos = $FORM{'StartFile'};
			}

		# These hashes are used later to update pending.txt via SaveLinksToFileEx

		my %crawler_results = ();
		my %valid = ('is_error' => 0);
		my %invalid = ('is_error' => 1);

		# This loads the generic realm update code, which will be eval'ed:

		my $i_line = $start_pos;
		my %code = ();
		&realm_interact( $p_realm_data, $Rules{'sql: enable'}, \%code );
		my ($obji, $p_rhandlei, $p_whandlei, $record, $record_err, $pagecount, $write_err) = ();

		if ($start_pos > 0) {
			eval $code{'resume'};
			if ($const{'embedded_err_msg'}) {
				$err = $const{'embedded_err_msg'};
				next Err;
				}
			}
		else {
			if ($Rules{'sql: enable'}) {
				# delete all entries at the beginning:
				$err = &db_exec( "DELETE FROM $Rules{'sql: table name: addresses'} WHERE realm_id = $$p_realm_data{'realm_id'}" );
				next Err if ($err);
				}
			eval $code{'init'};
			if ($const{'embedded_err_msg'}) {
				$err = $const{'embedded_err_msg'};
				next Err;
				}
			}
		die $@ if $@;

		$| = 1;


		&pppstr(391, $$p_realm_data{'html_name'} );

		my $fr = &fdse_filter_rules_new($p_realm_data);


		&pppstr(487, &he($Rules{'ext'}), "$const{'admin_url'}&amp;Action=GeneralRules&amp;Edit=Ext" );


		my $gf = &GetFiles_new();

		$err = $gf->create_file_list(
			'base_dir' => $$p_realm_data{'base_dir'},
			'base_url' => $$p_realm_data{'base_url'},
			'fr'    => \$fr,
			'tempfile' => $$p_realm_data{'file'} . ".temp_file_list.txt",
			'no_older_than' => 900,
			'verbose' => 1,
			);
		next Err if ($err);

		$FORM{'TotalValidFiles'} = $gf->{'count'};

		&pppstr(224, $FORM{'TotalValidFiles'}, $$p_realm_data{'base_dir'} );

		if ($start_pos) {
			&pppstr(230, $start_pos );
			$gf->resume_file_position( $start_pos );
			}
		else {
			print "<p>$str[231]</p>";
			}

		$FORM{'truecount'} = 0 unless ($FORM{'truecount'});

		my $NextLink = "$const{'admin_url'}&amp;Action=rebuild&amp;TotalValidFiles=$FORM{'TotalValidFiles'}&amp;Realm=$$p_realm_data{'url_name'}";

		&pppstr(192, "<a href=\"$NextLink&truecount=$FORM{'truecount'}&StartFile=$start_pos\">$str[193]</a>" );

		my $infile_count = $start_pos;
		my $success_count = $start_pos;

		my $intro = <<"EOM";

<table border="1" cellpadding="4" cellspacing="1" width="100%">
<tr>
	<th width="10%">$str[113]</th>
	<th width="10%">$str[153]</th>
	<th width="30%">$str[369]</th>
	<th width="50%">$str[74]</th>
</tr>

EOM


		my $b_table_open = 0;

		my ($lastmodt, $size, $abs_file, $basename, $URL) = ();

		while (1) {
			($lastmodt, $size, $abs_file, $basename, $URL) = $gf->get_next_file();
			$infile_count++;
			last unless ($URL);

			if ((0 == $b_table_open) and (not $const{'is_cmd'})) {
				print $intro;
				$b_table_open = 1;
				}

			my %pagedata = ();
			my $index_url = '';

			($err, $index_url) = &pagedata_from_file( $abs_file, $URL, \%pagedata, \$fr );
			if ($err) {
				# Is Error...
				if ($const{'is_cmd'}) {
					print "$str[73]: '$basename' - $err.\n";
					}
				else {
					print qq!<tr><td colspan="4" class="fdtan"><b>$str[73]:</b> '$basename' - $err.</td></tr>\n!;
					}
				next;
				}

			my $html_Size = &FormatNumber( $pagedata{'size'}, 0, 1, 0, 1, $Rules{'ui: number format'} );
			my $fileage = &get_age_str( time() - $pagedata{'lastmodtime'} );


			if ($const{'is_cmd'}) {
				print "URL $URL...\n";
				}
			else {
				my @var = &he($basename,$URL);

print <<"EOM";

<tr class="fdtan">
	<td align="right" nowrap="nowrap">$fileage</td>
	<td align="right" nowrap="nowrap">$html_Size bytes</td>
	<td>$var[0]</td>
	<td>$var[1]</td>
</tr>

EOM
				}

			$crawler_results{$index_url} = \%valid;

			eval $code{'insert'};
			die $@ if $@;
			if ($const{'embedded_err_msg'}) {
				$err = $const{'embedded_err_msg'};
				next Err;
				}
			last if ($write_err);

			$success_count++;
			$FORM{'truecount'}++;

			my $duration = time() - $private{'script_start_time'};


			if (($FORM{'UseTimeout'}) and ($Rules{'timeout'})) {
				last if ($duration > $Rules{'timeout'});
				}

			if (($FORM{'TotalValidFiles'}) and (0 == $success_count % 10) and (not $const{'is_cmd'})) {

				my $percent = &FormatNumber( 100 * $success_count / $FORM{'TotalValidFiles'}, 2, 1, 0, 1, $Rules{'ui: number format'} );
				$| = 1;
				print "</table>";
				$b_table_open = 0;
				&pppstr(233, "$percent%", $success_count, $FORM{'TotalValidFiles'}, $duration, $Rules{'timeout'} );
				$| = 0;
				}

			}
		print '</table>' if ($b_table_open);

		if ($write_err) {
			$err = $gf->quit(1);
			next Err if ($err);

			&ppstr(64, $write_err );
			eval $code{'abort'};
			die $@ if $@;
			if ($const{'embedded_err_msg'}) {
				$err = $const{'embedded_err_msg'};
				next Err;
				}
			last Err;
			}
		elsif ($infile_count < ($FORM{'TotalValidFiles'} - 1)) {
			$err = $gf->quit(1);
			next Err if ($err);

			eval $code{'suspend'};
			die $@ if $@;
			if ($const{'embedded_err_msg'}) {
				$err = $const{'embedded_err_msg'};
				next Err;
				}
			$NextLink .= "&truecount=$FORM{'truecount'}&StartFile=$infile_count";

			my $advice = &pstr(211, $Rules{'time interval between restarts'}, $NextLink );

print <<"EOM";

<meta http-equiv="refresh" content="$Rules{'time interval between restarts'};URL=$NextLink" />
<p><b>$str[210]:</b></p>
<blockquote>
	<p>$advice</p>
</blockquote>

EOM

			&pppstr(105, &FormatNumber( $FORM{'truecount'}, 0, 1, 0, 1, $Rules{'ui: number format'} ) );
			}
		else {
			$err = $gf->quit(0);
			next Err if ($err);


			eval $code{'finish'};
			die $@ if $@;
			if ($const{'embedded_err_msg'}) {
				$err = $const{'embedded_err_msg'};
				next Err;
				}
			$err = $realms->setpagecount($$p_realm_data{'name'}, $FORM{'truecount'}, 1);
			delete $FORM{'truecount'};
			next Err if ($err);
			&ppstr(174, $str[229] );
			$is_complete = 1;
			}
		$err = &SaveLinksToFileEx( $p_realm_data, \%crawler_results );
		next Err if ($err);
		&pppstr(232, time() - $private{'script_start_time'} );
		last Err;
		}
	$sth_getnext->finish() if ($sth_getnext);
	$sth_insert->finish() if ($sth_insert);
	$sth_update->finish() if ($sth_update);
	$sth_delete->finish() if ($sth_delete);
	$dbh->disconnect() if ($dbh);
	return ($err, $is_complete);
	}





sub AdminVersion {
	my %pagedata = @_;

	my $ue_url = &url_encode( $pagedata{'url'} );
	my $type = 1;
	my $ue_realm = '';

	my ($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
	if ((not $err) and ($p_realm_data)) {
		$ue_realm = $$p_realm_data{'url_name'};
		$type = $$p_realm_data{'type'};
		}

	if ($type == 5) {
		# runtime -
		$pagedata{'admin_options'} = '';
		}
	elsif ($type == 4) {
		# file-system; edit, delete, no crawl

	$pagedata{'admin_options'} = <<"EOM";

[ <a href="$const{'admin_url'}&amp;Action=Edit&amp;URL=$ue_url&amp;Realm=$ue_realm">$str[411]</a> |
 <a href="$const{'admin_url'}&amp;Action=DeleteRecord&amp;URL=$ue_url&amp;Realm=$ue_realm" onclick="return confirm('$str[108]');">$str[430]</a> ]

EOM

		}
	else {

	$pagedata{'admin_options'} = <<"EOM";

[ <a href="$const{'admin_url'}&amp;Action=Edit&amp;URL=$ue_url&amp;Realm=$ue_realm">$str[411]</a> |
 <a href="$const{'admin_url'}&amp;Action=AddURL&amp;URL=$ue_url&amp;Realm=$ue_realm">$str[444]</a> |
 <a href="$const{'admin_url'}&amp;Action=DeleteRecord&amp;URL=$ue_url&amp;Realm=$ue_realm" onclick="return confirm('$str[108]');">$str[430]</a> ]

EOM
		}

	$pagedata{'redirector'} = "$const{'script_name'}?NextLink=";

	return &StandardVersion(0, %pagedata);
	}





sub ui_ReviewIndex {
	my $err = '';
	Err: {

		my $p_realm_data = ();
		($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
		next Err if ($err);

		my $start_pos = $FORM{'Start'} || 1;
		my $max_results_to_show = $Rules{'crawler: max pages per batch'};

print <<"EOM";

	<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> / $str[154] '$$p_realm_data{'html_name'}'</b></p>

EOM

		my %crawler_results = ();
		$err = &query_realm( $$p_realm_data{'name'}, '', $start_pos - 1, $max_results_to_show, \%crawler_results);
		next Err if ($err);

		my $URL = '';

		my $total = $start_pos - 1 + scalar (keys %crawler_results);

		my $linkhits = "$const{'admin_url'}&amp;Realm=$$p_realm_data{'url_name'}&amp;Action=Review&amp;Start=";

		my $b_is_exact_count = 1;
		my $maximum = $$p_realm_data{'pagecount'};
		if (($total) and (not ($$p_realm_data{'pagecount'}))) {
			$maximum = $total;
			$b_is_exact_count = 0;
			}

		my ($jump_sum, $jumptext) = &str_jumptext( $start_pos, $max_results_to_show, $maximum, $linkhits, $b_is_exact_count );

		my $Count = $start_pos;

		my $nresults = scalar (keys %crawler_results);
		if ($nresults) {


			print $jump_sum;
			print $jumptext;

			foreach (sort (keys %crawler_results)) {
				my $p_data = $crawler_results{$_};
				$$p_data{'rank'} = $Count;
				print &AdminVersion(%$p_data);
				$Count++;
				}

			print $jump_sum;
			print $jumptext;

			}
		else {
			print "<p>$str[235]</p>\n";
			}

		if ($Count < ($start_pos + $max_results_to_show)) {
			print "<p><b>$str[236]:</b> $str[238].</p>\n";
			}
		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}





sub ui_UserInterface {
	my $err = '';
	Err: {
		local $_;

		my $subaction = $FORM{'subaction'} || '';

		my %subactions = (
			'' => $str[152],
			'EditTemplate' => $str[411],
			'SaveTemplate' => $str[362],
			'SaveSettings' => $str[362],
			'Write' => $str[362],

			'IL' => $str[503],

			);

		if (defined($subactions{$subaction})) {
			print "<p><b><a href=\"$const{'admin_url'}\" target=\"_top\">$str[96]</a> / <a href=\"$const{'admin_url'}&amp;Action=UserInterface\">$str[165]</a> / $subactions{$subaction}</b></p>\n";
			}

		my %name_to_file = (
			'Link Line 1' => 'linkline1.txt',
			'Link Line 2' => 'linkline2.txt',
			'Line Listing' => 'line_listing.txt',
			'Main Footer' => 'footer.htm',
			'Main Header' => 'header.htm',
			'Search Form' => 'searchform.htm',
			'Search Tips' => 'tips.htm',
			'Style Sheet' => 'style.inc',
			);

		my %name_to_desc = (
			'Line Listing' => $str[237],
			'Main Footer' => $str[239],
			'Main Header' => $str[240],
			'Search Form' => $str[241],
			'Search Tips' => $str[242],
			'Style Sheet' => $str[243],
			'Link Line 1' => $str[171],
			'Link Line 2' => $str[169],
			);


		if ($subaction eq 'IL') {
			# install language pack...

			my @langfiles_over = (
				'admin_ads.txt',
				'admin_fr.txt',
				'admin_fr2.txt',
				'admin_navbar.txt',
				'admin_pass1.txt',
				'admin_pass2.txt',
				'admin_personal.txt',
				'admin_ui.txt',
				'settings_desc.txt',
				'strings.txt',
				);

			my @langfiles_preserve_old = (
				'linkline1.txt',
				'linkline2.txt',
				'searchform.htm',
				'tips.htm',
				);

			my $foldername = $FORM{'fn'};
			if ($foldername =~ m!\W!) {
				$err = &pstr(504,&he($foldername));
				next Err;
				}

			unless (-d "templates/$foldername") {
				unless (mkdir("templates/$foldername",0777)) {
					$err = &pstr(505,&he("templates/$foldername"),$!);
					next Err;
					}
				chmod(0777, "templates/$foldername"); # for good measure - sometimes needed
				}

			&pppstr(506, &pstr(507, $foldername, $VERSION));

			my $base_path = "http://www.xav.com/latest/translator/$VERSION/$foldername";


			# temporarily set some overrides
			$Rules{'crawler: rogue'} = 1;
			$Rules{'max characters: file'} = &max($Rules{'max characters: file'},16777216);
			$Rules{'crawler: max redirects'} = 6;
			$Rules{'minimum page size'} = 0;
			my $crawler = &Crawler_new();

			my $langfile;
			foreach $langfile (@langfiles_over) {
				print "<p>-&gt; $str[195] $langfile...</p>\n";
				my %webrq = $crawler->webrequest( "page" => "$base_path/$langfile" );
				if ($webrq{'err'}) {
					&ppstr(64, $webrq{'err'} );
					&pppstr(508, $base_path, "searchdata/templates/$foldername");
					last Err;
					}
				$err = &WriteFile( "templates/$foldername/$langfile", $webrq{'text'} );
				next Err if ($err);
				}

			foreach $langfile (@langfiles_preserve_old) {
				if (-e "templates/$foldername/$langfile") {
					&pppstr(506, &pstr(509, $langfile));
					next;
					}
				print "<p>-&gt; $str[195] $langfile...</p>\n";
				my %webrq = $crawler->webrequest( "page" => "$base_path/$langfile" );
				if ($webrq{'err'}) {
					&ppstr(64, $webrq{'err'} );
					&pppstr(508, $base_path, "searchdata/templates/$foldername");
					last Err;
					}
				$err = &WriteFile( "templates/$foldername/$langfile", $webrq{'text'} );
				next Err if ($err);
				}
			&ppstr(174, &pstr(510, $foldername));

			my $cache = 'valid_languages_cache.txt';
			if (-e $cache) {
				unlink($cache);
				}

			last Err;
			}

		if ($subaction eq 'EditTemplate') {

			my $template = $FORM{'template'};
			my $html_template = &he( $template );

			unless ($name_to_file{ $template }) {
				$err = &pstr(244, $html_template );
				next Err;
				}

			my $text = '';

			my $file = '';
			if (-e "templates/$Rules{'language'}/$name_to_file{ $template }") {
				$file = "templates/$Rules{'language'}/$name_to_file{ $template }";
				}
			elsif (-e "templates/$name_to_file{ $template }") {
				$file = "templates/$name_to_file{ $template }";
				}
			else {
				$err = &pstr(245, $name_to_file{ $template } );
				next Err;
				}

			($err, $text) = &ReadFile( $file );
			next Err if ($err);

			# Collapse multiple line breaks:
			$text =~ s!\015\012!\012!sg;
			$text =~ s!\015!\012!sg;
			$text =~ s!\012+!\n!sg;

			$text = &he( $text );

			my $html_file = &he( $file );

			my $descr = &pstr(246, $html_template, $html_file );

print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="UserInterface" />
<input type="hidden" name="subaction" value="SaveTemplate" />
<input type="hidden" name="template" value="$html_template" />

<p>$descr</p>
<p><textarea name="filetext" rows="20" cols="95">$text</textarea></p>

<p><input type="submit" class="submit" value="$str[362]" /></p>
<p><br /></p>

</form>


EOM


			last Err;
			}
		elsif ($subaction eq 'SaveTemplate') {

			if ($const{'is_demo'}) {
				&ppstr(53, $str[435] );
				last Err;
				}

			my $template = $FORM{'template'};

			unless ($name_to_file{ $template }) {
				$err = &pstr(244, &he($template) );
				next Err;
				}

			my $file = "templates/$Rules{'language'}/$name_to_file{ $template }";

			if ((-e "templates/$name_to_file{ $template }") and (not (-e $file))) {
				$file = "templates/$name_to_file{ $template }";
				}
			$err = &WriteFile( $file, $FORM{'filetext'} );
			next Err if ($err);
			&ppstr(174, &pstr(469,$name_to_file{$template}));
			last Err;
			}
		elsif ($subaction eq 'SaveSettings') {
			if ($const{'is_demo'}) {
				&ppstr(53, $str[435] );
				last Err;
				}

			my $old_lang = $Rules{'language'};
			my $new_lang = $FORM{'language'};

			$FORM{'ui: search form display'} = 2 * $FORM{'sfp2'} + $FORM{'sfp1'};

			foreach ('language', 'ui: number format', 'ui: date format','ui: search form display') {
				if (not defined($FORM{$_})) {
					$err = "invalid argument - required parameter '$_' is not defined";
					next Err;
					}
				$err = &WriteRule($_, $FORM{$_});
				next Err if ($err);
				}

			if ($old_lang ne $new_lang) {
				&ppstr( 174, &pstr(490, &he( $old_lang, $new_lang ) ) );
				}

			&ppstr(174,$str[114]);
			last Err;
			}
		elsif ($subaction eq 'SS2') {
			print "<p><b><a href=\"$const{'admin_url'}\" target=\"_top\">$str[96]</a> / <a href=\"$const{'admin_url'}&amp;Action=UserInterface\">$str[165]</a> / <a href=\"$const{'admin_url'}&amp;Action=UserInterface&amp;subaction=viewmap\">$str[473]</a> / $str[362]</b></p>\n";

			if ($const{'is_demo'}) {
				&ppstr(53, $str[435] );
				last Err;
				}

			my $b_need_rebuild = 0;

			foreach ('character conversion: accent insensitive', 'character conversion: case insensitive') {
				$b_need_rebuild = 1 if ($Rules{$_} ne $FORM{$_});
				$err = &WriteRule($_, $FORM{$_});
				next Err if ($err);
				}
			&ppstr(174,$str[114]);
			print '<P>' . $str[518] . '</P>' if ($b_need_rebuild);
			last Err;
			}
		elsif ($subaction eq 'viewmap') {

			print "<p><b><a href=\"$const{'admin_url'}\" target=\"_top\">$str[96]</a> / <a href=\"$const{'admin_url'}&amp;Action=UserInterface\">$str[165]</a> / <a href=\"$const{'admin_url'}&amp;Action=UserInterface&amp;subaction=viewmap\">$str[473]</a></b></p>\n";

			my $ex = '&' . 'uuml';

print &SetDefaults(<<"EOM",\%Rules);

<p><b>$str[473]</b> (<a href="$const{'help_file'}1095.html" target="_blank">$str[432]</a>)</p>

$const{'AdminForm'}
<input type="hidden" name="Action" value="UserInterface" />
<input type="hidden" name="subaction" value="SS2" />
<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$str[481]</th>
	<th>$str[60]</th>
</tr>
<tr class="fdtan">
	<td><input type="radio" name="character conversion: accent insensitive" value="1" /></td>
	<td>$str[59]</td>
	<td>m$ex;ller == mueller</td>
</tr>
<tr class="fdtan">
	<td><input type="radio" name="character conversion: accent insensitive" value="0" /></td>
	<td>$str[58]</td>
	<td>m$ex;ller != mueller</td>
</tr>
<tr>
	<th colspan="2">$str[481]</th>
	<th>$str[60]</th>
</tr>
<tr class="fdtan">
	<td><input type="radio" name="character conversion: case insensitive" value="1" /></td>
	<td>$str[57]</td>
	<td>Miller == miller</td>
</tr>
<tr class="fdtan">
	<td><input type="radio" name="character conversion: case insensitive" value="0" /></td>
	<td>$str[56]</td>
	<td>Miller != miller</td>
</tr>
</table>
<p><input type="submit" class="submit" value="$str[362]" /></p>
</form>


<p>$str[485]</p>
<ol>
	<li><p>$str[484]</p></li>
	<li><p>$str[483]</p></li>
</ol>
<p>$str[482]</p>


EOM


			&create_conversion_code(1);
			last Err;
			}

		print "<p><b>$str[163]</b></p>\n";
		print "<p>$str[164]</p>\n";

		&ui_GeneralRules( $str[165], 'UserInterface',
			'default match',
			'default search terms',
			'default substring match',
			'hits per page',
			'show examples: enable',
			'show examples: number to display',
			'handling url search terms',
			'no frames',
			'sorting: randomize equally-relevant search results',
			'sorting: default sort method',
			'sorting: time sensitive',
			'user language selection',
			);

		my %support_lang = (
			'ar' => '&#1575;&#1604;&#1593;&#1585;&#1576;&#1610;&#1577;',
			'bs' => 'Bosanski',
			'dutch' => 'Nederlands',
			'english' => 'English',
			'fi' => 'Finnish',
			'french' => 'Fran&#231;ais',
			'german' => 'Deutsch',
			'italian' => 'Italiano',
			'lv' => 'Latviski',
			'nb' => 'Norsk-bokm&#229;l',
			'portuguese' => 'Portugu&#234;s',
			'ro' => 'Romanian',
			'ru' => '&#1068;&#1103;&#1101;&#1101;&#1094;&#1092;&#1093;',
			'sl' => 'Slovenski',
			'spanish' => 'Espa&#241;ol',
			'sr' => 'Srpski',
			'sv' => 'Svenska',
			'tl' => 'Tagalog',
			'tr' => '&#84;&#252;&#114;&#107;&#231;&#101;',
			);

		my $lang_opt = '';
		if (opendir(DIR, 'templates')) {
			my @folders = sort readdir(DIR);
			closedir(DIR);
			foreach (@folders) {
				next unless (-e "templates/$_/strings.txt");
				unless (open(FILE, "<templates/$_/strings.txt" )) {
					&ppstr( 64, &pstr(44, "templates/$_/strings.txt", $! ) );
					next;
					}
				my ($ver, $selfname) = (<FILE>, <FILE>);
				close(FILE);
				if ($ver =~ m!^VERSION $VERSION!) {
					$lang_opt .= qq!<input type="radio" name="language" value="$_" id="lang_$_" /><label for="lang_$_"> $selfname / $_</label><br />!;
					delete $support_lang{$_};
					}
				else {
					$lang_opt .= qq![<a href="$const{'admin_url'}&amp;Action=UserInterface&amp;subaction=IL&amp;fn=$_" class="onbrown">$str[512]</a>]  !;
					$lang_opt .= "$selfname / $_<br />" . &pstr(511,$ver) . "<br />";
					delete $support_lang{$_};
					}
				}
			}
		foreach (sort keys %support_lang) {
			$lang_opt .= qq![<a href="$const{'admin_url'}&amp;Action=UserInterface&amp;subaction=IL&amp;fn=$_" class="onbrown">$str[512]</a>] !;
			$lang_opt .= "$support_lang{$_} / $_<br />";
			$support_lang{$_} = 0;
			}


		my $abs_url = &get_absolute_url();
		my $code = &str_search_form( $abs_url );

		# Collapse multiple line breaks:
		$code =~ s!\015\012!\012!sg;
		$code =~ s!\015!\012!sg;

		my $template_list = '';
		foreach (sort keys %name_to_desc) {
			my $url_name = &url_encode( $_ );
			my $lang = $Rules{'language'};
			my $basefile = $name_to_file{ $_ };
			unless (-e "templates/$Rules{'language'}/$basefile") {
				$lang = '-';
				}
			$template_list .= qq!<tr class="fdtan"><td align="center"><a href="$const{'admin_url'}&amp;Action=UserInterface&amp;subaction=EditTemplate&amp;template=$url_name" class="onbrown"><b>$_</b></a></td><td align="center">$lang</td><td>$name_to_desc{$_}<br /></td></tr>\n!;
			}

print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="UserInterface" />
<input type="hidden" name="subaction" value="SaveSettings" />

EOM

		my %defaults = %const;
		$defaults{'html_language_options'} = $lang_opt;
		$defaults{'html_templates'} = $template_list;


		$Rules{'search_code'} = $code;
		$Rules{'simple_code'} = <<"EOM";
<form method="get" action="$abs_url">
	<label for="fdse_TermsEx">$str[470] </label><input name="Terms" id="fdse_TermsEx" />
	<input type="submit" value="$str[537]" />
</form>
EOM
		if ($Rules{'default search terms'}) {
			my $ht = &he($Rules{'default search terms'});
			$Rules{'simple_code'} =~ s!name="Terms"!name="Terms" value="$ht"!s;
			}


		$Rules{'link_code'} = '<p>' . $str[470] . " <a href=\"$abs_url?Terms=" . &url_encode($str[46]) . "\">$str[46]</a>" . '</p>';

		$defaults{'html_search_code'} = $code;
		$defaults{'html_simple_code'} = $Rules{'simple_code'};
		$defaults{'html_link_code'} = $Rules{'link_code'};
		my $text = &PrintTemplate( 1, 'admin_ui.txt', $Rules{'language'}, \%defaults );
		$Rules{'sfp1'} = $Rules{'ui: search form display'} % 2;
		$Rules{'sfp2'} = ($Rules{'ui: search form display'} < 2) ? 0 : 1;
		print &SetDefaults($text, \%Rules);
		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}





sub save_custom_metadata {
	my ($url, %metadata) = @_;
	my $err = '';
	Err: {

		unless ($Rules{'use dbm routines'}) {
			$err = $str[539];
			next Err;
			}

		eval {
			my %custom = ();
			dbmopen( %custom, 'custom_metadata', 0666 ) || die &pstr( 43, 'custom_metadata', $! );
			if (%metadata) {
				my $str = '';
				my @pairs = ();
				foreach (keys %metadata) {
					push(@pairs, "$_=" . &url_encode($metadata{$_}) );
					}
				$str = join( ' ', @pairs );
				$custom{$url} = $str;
				}
			else {
				delete $custom{$url};
				}
			dbmclose( %custom );
			};
		if ($@) {
			$err = &pstr(67, &he($@), "$const{'help_file'}1169.html" );
			}
		last Err;
		}
	return $err;
	};



sub ui_EditRecord {
	my $err = '';
	Err: {
		my $sa = $FORM{'sa'} || '';


		if ($sa eq 'write') {

			my $p_realm_data = ();
			($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
			next Err if ($err);

			my ($old_url,$new_url) = ('', '');

			($err,$old_url) = &uri_parse($FORM{'EditURL'});
			next Err if ($err);

			($err,$new_url) = &uri_parse($FORM{'url'});
			next Err if ($err);

			my $uurl = &url_encode($new_url);

print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit">$str[94]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit&amp;URL=$uurl&amp;Realm=$$p_realm_data{'url_name'}">$str[522]</a> /
	$str[362]
</b></p>

EOM



			foreach ('title','description','keywords') {
				$FORM{$_} = '' unless (defined($FORM{$_}));
				$FORM{$_} =~ s!\r|\n|\=!!sg;

				$FORM{$_} =~ s!\<!&lt;!sg;
				$FORM{$_} =~ s!\>!&gt;!sg;
				$FORM{$_} =~ s!\"!&quot;!sg;
				}

			my %crawler_results = ();
			my %pagedata;

			if ($old_url ne $new_url) {
				# Okay, they're doing a rename. well this is a little more tricky
				# lookup a full %pagedata hash on the old record
				# build a new insert %pagedata hash with the new meta-info
				# build a 'is_error' %pagedata hash forl the old url


				$err = &query_realm( $$p_realm_data{'name'}, quotemeta($old_url), 0, 1, \%crawler_results );
				next Err if ($err);
				unless ($crawler_results{$old_url}) {
					$err = &pstr(249,&he($old_url),$$p_realm_data{'html_name'} );
					next Err;
					}
				#end changes

				# updated record:
				my $p_pagedata = $crawler_results{$old_url};
				%pagedata = %$p_pagedata;

				$pagedata{'is_error'} = 0;
				$pagedata{'url'} = $new_url;
				$pagedata{'title'} = $FORM{'title'};
				$pagedata{'description'} = $FORM{'description'};
				$pagedata{'keywords'} = $FORM{'keywords'};

				# kill record:
				my %kill = (
					'is_error' => 1,
					'url' => $old_url,
					);
				$crawler_results{ $old_url } = \%kill;
				}
			else {

				%pagedata = (
					'is_error' => 0,
					'is_update' => 1,

					'url' => $new_url,
					'new_url' => $new_url,
					'title' => $FORM{'title'},
					'description' => $FORM{'description'},
					'keywords' => $FORM{'keywords'},
					);
				}


			$pagedata{'size'} = $FORM{'size'};
			unless ($pagedata{'size'} =~ m!^\d+$!) {
				$err = &pstr(69,'size',0,999999);
				next Err;
				}
			$pagedata{'promote'} = $FORM{'promote'};
			unless ($pagedata{'promote'} =~ m!^\d+$!) {
				$err = &pstr(69,'promote',1,99);
				next Err;
				}
			$crawler_results{$new_url} = \%pagedata;


			my ($total_records, $new_records, $updated_records, $deleted_records) = (0, 0, 0, 0);

			($err, $total_records, $new_records, $updated_records, $deleted_records) = &update_realm( $$p_realm_data{'name'}, \%crawler_results );
			next Err if ($err);

			&pppstr(289, $total_records, $$p_realm_data{'html_name'}, $new_records, $updated_records, $deleted_records );

my $html_code = &he(<<"EOM");

<html>
<head>
  <title>$pagedata{'title'}</title>
  <meta name="description" content="$pagedata{'description'}">
  <meta name="keywords" content="$pagedata{'keywords'}">
  ....
EOM

			&ppstr(53, $str[252] );

print <<"EOM";

<p><form><textarea rows="8" cols="80" name="x">$html_code</textarea></form></p>

EOM

			last Err unless ($Rules{'use dbm routines'});

			my %persist_meta = ();
			if ($FORM{'persist_title'}) {
				$persist_meta{'title'} = $pagedata{'title'};
				}
			if ($FORM{'persist_description'}) {
				$persist_meta{'description'} = $pagedata{'description'};
				}
			if ($FORM{'persist_keywords'}) {
				$persist_meta{'keywords'} = $pagedata{'keywords'};
				}

			$err = &save_custom_metadata( $new_url, %persist_meta );
			next Err if ($err);
			last Err;
			}

		my $query_pattern = $FORM{'query_pattern'};

		$query_pattern = defined($query_pattern) ? $query_pattern : '';
		my $html_query_pattern = &he( $query_pattern );

		if ($query_pattern) {

print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit">$str[94]</a> /
	$str[263]
</b></p>

EOM


			$err = &check_regex($query_pattern);
			next Err if ($err);

			my @kill_us = ();
			$query_pattern = ".*$query_pattern.*" unless ($query_pattern =~ m!\.\*!);

			my $p_realm_data = ();
			($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
			next Err if ($err);


			my %crawler_results = ();

			$err = &query_realm( $$p_realm_data{'name'}, $query_pattern, 0, $Rules{'crawler: max pages per batch'}, \%crawler_results );
			next Err if ($err);

			@kill_us = sort (keys %crawler_results);

			my $query_count = scalar @kill_us;

			&pppstr(273, &he($query_pattern), $query_count );

			if ($query_count == 0) {
				print '<p>' . $str[19] . '</p>';
				}
			else {

				my $x = 0;
				foreach (sort @kill_us) {
					$x++;
					my $hurl = &he($_);

					my $p_data = $crawler_results{$_};

					print &AdminVersion(
						'rank' => $x,
						%$p_data,
						);

					}
				}
			last Err;
			}

		if ($sa eq 'delete') {

print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit">$str[94]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit&amp;sa=list">$str[523]</a> /
	$str[95]
</b></p>

EOM

			unless ($Rules{'use dbm routines'}) {
				$err = $str[539];
				next Err;
				}


			local $_;
			foreach (keys %FORM) {
				next unless (m!^del:(.+)$!);
				my $url = $1;
				$err = &save_custom_metadata( $url );
				next Err if ($err);
				}

			&ppstr(174,$str[267]);
			print $str[524];
			last Err;
			}

		if ($sa eq 'list') {

print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit">$str[94]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit&amp;sa=list">$str[523]</a> /
	$str[152]
</b></p>

EOM

			unless ($Rules{'use dbm routines'}) {
				$err = $str[539];
				next Err;
				}

			eval {

				my %data_by_url = ();
				my %realm_by_url = ();

				dbmopen( %data_by_url, 'custom_metadata', 0666 ) || die &pstr( 43, 'custom_metadata', $! );

				my $count = scalar keys %data_by_url;

				my ($obj, $p_rhandle) = ();
				$obj = &LockFile_new(
					'create_if_needed' => 1,
					);
				($err, $p_rhandle) = $obj->Read('search.pending.txt');
				next Err if ($err);
				while (defined($_ = readline($$p_rhandle))) {
					next unless (m!^(\S+) (\S+) (\d+)(\r|\n|\015|\012)$!s);
					if ((defined($data_by_url{$1})) and ($3 > 2)) {
						$realm_by_url{$1} = $2;
						}
					}
				$err = $obj->Close();
				next Err if ($err);

				unless ($count) {
					print "<p>$str[266]</p>\n";
					}
				else {

print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="Edit" />
<input type="hidden" name="sa" value="delete" />

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$str[74]</th>
	<th colspan="2">Actions</th>
</tr>

EOM


					foreach (sort keys %data_by_url) {

						my $uurl = &url_encode($_);
						my $hurl = &he($_);

						if (defined($realm_by_url{$_})) {

print <<"EOM";

<tr class="fdtan">
	<td colspan="2">$hurl<br /></td>
	<td align="center"><a href="$const{'admin_url'}&amp;Action=Edit&amp;URL=$uurl&amp;Realm=$realm_by_url{$_}" class="onbrown">$str[411]</a></td>
	<td align="center"><input type="checkbox" name="del:$hurl" value="1" /></td>
</tr>


EOM


							}
						else {

print <<"EOM";

<tr class="fdtan">
	<td colspan="2">$hurl<br /></td>
	<td align="center">$str[265]</td>
	<td align="center"><input type="checkbox" name="del:$hurl" value="1" checked="checked" /></td>
</tr>


EOM


							}

						my $data = $data_by_url{$_};
						foreach (sort (split(m! !s, $data))) {
							next unless (m!^(.+)=(.*?)$!);
							my ($attrib, $value) = ($1, &he(&ud($2)));
print <<"EOM";

<tr class="fdtan">
	<td align="right">$attrib:</td>
	<td>$value</td>
	<td colspan="2"><br /></td>
</tr>


EOM



							}
						}



print <<"EOM";

<tr class="fdtan">
	<td colspan="4" align="right"><input type="submit" class="submit" value="$str[525]" /></td>
</tr>
</table>
</form>

EOM
					dbmclose( %data_by_url );
					print $str[524];
					}

				};
			if ($@) {
				$err = &pstr(67, &he($@), "$const{'help_file'}1169.html" );
				next Err;
				}


			last Err;
			}
		elsif (($FORM{'URL'}) and ($FORM{'URL'} ne 'http://')) {

			my $EditURL;
			($err,$EditURL) = &uri_parse($FORM{'URL'});
			next Err if ($err);

			my $p_realm_data = ();
			($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
			next Err if ($err);


			my $uurl = &url_encode($EditURL);



print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit">$str[94]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit&amp;URL=$uurl&amp;Realm=$$p_realm_data{'url_name'}">$str[522]</a> /
	$str[152]
</b></p>

EOM




			my $file = $$p_realm_data{'file'};

			if ($$p_realm_data{'is_runtime'}) {
				$err = $str[248];
				next Err;
				}

			my $pattern = quotemeta($EditURL);

			my %crawler_results = ();
			$err = &query_realm( $$p_realm_data{'name'}, $pattern, 0, 1, \%crawler_results );
			next Err if ($err);

			unless (%crawler_results) {
				$err = &pstr(249,&he($EditURL),$$p_realm_data{'html_name'} );
				next Err;
				}

			my $r_pagedata = $crawler_results{$EditURL};

			# this is just to set the checkbox defaults properly in the edit form...
			my %metadata = ();
			$err = &load_custom_metadata($EditURL, \%metadata);
			next Err if ($err);
			foreach ('title','description','keywords') {
				next unless (defined($metadata{$_}));
				$$r_pagedata{"persist_$_"} = 1;
				}





			print '<hr size="1" /><blockquote>';
			print &AdminVersion('rank' => 1, %$r_pagedata);
			print '</blockquote>';

print &SetDefaults(<<"EOM",$r_pagedata);

$const{'AdminForm'}
<input type="hidden" name="Action" value="Edit" />
<input type="hidden" name="sa" value="write" />
<input type="hidden" name="Realm" value="$$p_realm_data{'html_name'}" />
<input type="hidden" name="EditURL" value="$EditURL" />

<hr size="1" />

<table border="0" cellpadding="4" cellspacing="0">
<tr>
	<td align="right"><b>$str[250]:</b></td>
	<td><input name="title" size="60" onactivate="ch('fd_t');" /></td>
</tr>
<tr>
	<td align="right"><b>$str[74]:</b></td>
	<td><input name="url" size="60" /></td>
</tr>
<tr>
	<td align="right"><b>$str[153]:</b></td>
	<td><input name="size" size="8" maxlength="8" style="text-align:right" /> bytes</td>
</tr>
<tr>
	<td align="right"><b>$str[251]:</b></td>
	<td><input name="promote" size="2" maxlength="2" style="text-align:right" /></td>
</tr>
<tr>
	<td align="right" valign="top"><b>$str[63]:</b></td>
	<td><textarea name="description" rows="3" cols="60" onactivate="ch('fd_d');"></textarea></td>
</tr>
<tr>
	<td align="right" valign="top"><b>$str[151]:</b></td>
	<td><textarea name="keywords" rows="3" cols="60" onactivate="ch('fd_k');"></textarea></td>
</tr>
<tr>
	<td><br /></td>
	<td><input type="submit" class="submit" value="$str[362]" /></td>
</tr>
</table>

EOM
print &SetDefaults(<<"EOM",$r_pagedata) if ($Rules{'use dbm routines'});

<hr size="1" />

<p>$str[253]</p>

<table border="0">
<tr>
	<td align="right" width="120"><input type="checkbox" name="persist_title" value="1" id="fd_t" onactivate="quiet();" /></td>
	<td><b>$str[250]</b></td>
</tr>
<tr>
	<td align="right"><input type="checkbox" name="persist_description" value="1" id="fd_d" onactivate="quiet();" /></td>
	<td><b>$str[63]</b></td>
</tr>
<tr>
	<td align="right"><input type="checkbox" name="persist_keywords" value="1" id="fd_k" onactivate="quiet();" /></td>
	<td><b>$str[151]</b></td>
</tr>
</table>
<script type="text/javascript">
<!--
var b_stop = false;
function quiet () {
	b_stop = true;
	}
function ch (on) {
	if ((!b_stop) && (document) && (document.all) && (document.all(on))) {
		document.all(on).checked = true;
		}
	}
//-->
</script>

EOM

print <<"EOM";


<hr size="1" />

</form>

<p>$str[254]</p>
<p>$str[255]</p>
<p>$str[256]</p>

EOM
			}
		else {



print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=Edit">$str[94]</a> /
	$str[152]
</b></p>

EOM




			my ($count, $html_hidden, $html_tr) = $realms->html_select_ex('has_index_data', '', 'fdtan', 120);
			unless ($count) {
				$err = $str[257];
				next Err;
				}

print <<"EOM";

<p>$str[258]</p>

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$str[259]</th>
</tr>
<tr class="fdtan" valign="top">
	<td align="right" width="120"><b>$str[531]:</b></td>
	<td>

EOM

my $p_temp_data = ();
foreach $p_temp_data ($realms->listrealms('has_index_data')) {
	print "<a href=\"$const{'admin_url'}&amp;Action=Review&amp;Realm=" . &url_encode( $$p_temp_data{'name'} ) . "\" class=\"onbrown\">" . &he( $$p_temp_data{'name'} ) . "</a> ($$p_temp_data{'pagecount'})<br />\n";
	}


print <<"EOM";

	</td>
</tr>
</table>

<p><br /></p>

$const{'AdminForm'}
<input type="hidden" name="Action" value="Edit" />
$html_hidden

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$str[260]</th>
</tr>
<tr class="fdtan">
	<td align="right"><b>$str[261]:</b></td>
	<td><input name="query_pattern" /></td>
</tr>
$html_tr
</table>

<blockquote>
	<p><input type="submit" class="submit" value="$str[263]" /></p>
</blockquote>

</form>

<p>$str[264]</p>

EOM

			&pppstr(247, "$const{'admin_url'}&amp;Action=Edit&amp;sa=list") if ($Rules{'use dbm routines'});
			}


		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}





sub DeleteFromPending {
	my ($realm, $p_urls) = @_;
	my $delcount = 0;
	my $err = '';
	Err: {
		local $_;
		my $pattern = '^(';
		if (($p_urls) and ('ARRAY' eq ref($p_urls))) {
			foreach (@$p_urls) {
				$pattern .= quotemeta($_) . '|';
				}
			$pattern =~ s!\|$!!o;
			$pattern .= ') ';
			}
		else {
			$pattern .= '.*) ';
			}
		if ($realm) {
			$pattern .= quotemeta(&url_encode($realm));
			}
		else {
			$pattern .= '(\S+)';
			}
		$pattern .= ' \d+$';

		my ($obj, $p_rhandle, $p_whandle) = ();

		$obj = &LockFile_new(
			'create_if_needed' => 1,
			);
		($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('search.pending.txt');
		next Err if ($err);
		while (defined($_ = readline($$p_rhandle))) {
			if (m!$pattern!o) {
				$delcount++;
				next;
				}
			print { $$p_whandle } $_;
			}
		$err = $obj->Merge();
		next Err if ($err);
		}
	return ($err, $delcount);
	}





sub ui_DeleteRecord {
	my $err = '';
	Err: {

		unless ($FORM{'Realm'}) {



print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=DeleteRecord">$str[95]</a> /
	$str[152]
</b></p>

EOM


			my ($count, $html_hidden, $html_tr) = $realms->html_select_ex('has_index_data', '', 'fdtan', 120);
			unless ($count) {
				$err = $str[257];
				next Err;
				}

print <<"EOM";

<p>$str[258]</p>

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$str[259]</th>
</tr>
<tr class="fdtan" valign="top">
	<td align="right" width="120"><b>$str[531]:</b></td>
	<td>

EOM

my $p_temp_data = ();
foreach $p_temp_data ($realms->listrealms('has_index_data')) {
	print qq!<a href="$const{'admin_url'}&amp;Action=Review&amp;Realm=$$p_temp_data{'url_name'}" class="onbrown">$$p_temp_data{'html_name'}</a> ($$p_temp_data{'pagecount'})<br />\n!;
	}


print <<"EOM";

	</td>
</tr>
</table>

<p><br /></p>

$const{'AdminForm'}
<input type="hidden" name="Action" value="DeleteRecord" />
$html_hidden

<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th colspan="2">$str[260]</th>
</tr>
<tr class="fdtan">
	<td align="right"><b>$str[261]:</b></td>
	<td><input name="query_pattern" /></td>
</tr>
$html_tr
</table>

<blockquote>
	<p><input type="submit" class="submit" value="$str[263]" /></p>
</blockquote>

</form>

<p>$str[264]</p>

EOM
			last Err;
			}






		my @urls_to_delete = ();
		while (defined($_ = each %FORM)) {
			next unless (m!^URL\d*$!);
			push(@urls_to_delete, $FORM{$_});
			}


		my $p_realm_data = ();
		($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
		next Err if ($err);

		my $query_pattern = $FORM{'query_pattern'};

		$query_pattern = defined($query_pattern) ? $query_pattern : '';
		my $html_query_pattern = &he( $query_pattern );


		my %pagedata = ();
		my %crawler_results = ();


		if (@urls_to_delete) {



print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=DeleteRecord">$str[95]</a> /
	$str[430]
</b></p>

EOM


			my $URL = '';
			foreach $URL (@urls_to_delete) {
				my %pagedata = (
					'url' => $URL,
					'is_error' => 1,
					);
				$crawler_results{$URL} = \%pagedata;
				}
			my ($total_records, $new_records, $updated_records, $deleted_records) = (0, 0, 0, 0);
			($err, $total_records, $new_records, $updated_records, $deleted_records) = &update_realm( $$p_realm_data{'name'}, \%crawler_results );
			next Err if ($err);

			my $delcount = 0;
			($err, $delcount) = &DeleteFromPending( $$p_realm_data{'name'}, \@urls_to_delete );
			next Err if ($err);

			&ppstr(174, &pstr(178,$delcount,'search.pending.txt'));

			print "<blockquote>\n";
			foreach $URL (sort keys %crawler_results) {
				my $r_pagedata = $crawler_results{$URL};
				if ($$r_pagedata{'sub status msg'}) {
					print "URL '" . &he($URL) . "' - $$r_pagedata{'sub status msg'}<br />\n";
					}
				else {
					print "<b>$str[73]:</b> ";
					&ppstr(249, &he($URL), $$p_realm_data{'html_name'} );
					print ".<br />\n";
					}
				}
			print "</blockquote>\n";
			&pppstr(289, $total_records, $$p_realm_data{'html_name'}, $new_records, $updated_records, $deleted_records );

			my $default_forbid_url = $urls_to_delete[0];
			if ($query_pattern) {
				$default_forbid_url = $query_pattern;
				}
			$default_forbid_url = &he($default_forbid_url);



			&ppstr(269, '<blockquote><tt>&lt;meta name="robots" content="none" /&gt;</tt></blockquote>', <<"EOM");
$const{'AdminForm'}
<input type="hidden" name="Action" value="AddForbidSite" />
			<table border="0">
			<tr>
				<td><b>$str[261]:</b></td>
				<td><input name="URL" value="$default_forbid_url" size="60" /></td>
			</tr>
			<tr>
				<td><br /></td>
				<td><input type="submit" class="submit" value="$str[362]" /></td>
			</tr>
			</table>
</form>
EOM


			# did this guy just do a single deletion? advertise our new multiple delete feature:

			if ((1 == scalar @urls_to_delete) and (not $query_pattern)) {

				my $temp_url = $urls_to_delete[0];

				print "<p><b>$str[270]</b></p>\n";

				my $x = 0;
				while (1) {
					$x++;
					last if ($x > 10);
					if ($temp_url =~ m!^http://(.*)/!) {
						$temp_url = "http://$1";
						print "<p>$str[271] <a href=\"$const{'admin_url'}&amp;Action=DeleteRecord&amp;Realm=$$p_realm_data{'url_name'}&amp;query_pattern=" . &url_encode($temp_url) . "/.*\">" . &he($temp_url) . "/.*</a>.</p>\n";
						next;
						}
					last;
					}

				}



			last Err;
			}


		if ($query_pattern) {


print <<"EOM";

<p><b>
	<a href="$const{'admin_url'}" target="_top">$str[96]</a> /
	<a href="$const{'admin_url'}&amp;Action=ManageRealms">$str[520]</a> /
	<a href="$const{'admin_url'}&amp;Action=DeleteRecord">$str[95]</a> /
	$str[263]
</b></p>

<p><b>$str[272]</b></p>

EOM

			$err = &check_regex($query_pattern);
			next Err if ($err);

			my @kill_us = ();
			$query_pattern = ".*$query_pattern.*" unless ($query_pattern =~ m!\.\*!);

			my %crawler_results = ();

			my $max_results = ($Rules{'crawler: max pages per batch'} > 50) ? 50 : $Rules{'crawler: max pages per batch'};

			$err = &query_realm( $$p_realm_data{'name'}, $query_pattern, 0, $max_results, \%crawler_results );
			next Err if ($err);

			@kill_us = sort (keys %crawler_results);

			my $query_count = scalar @kill_us;

			&pppstr(273, &he($query_pattern), $query_count );

			if ($query_count) {

				if ($query_count == $max_results) {
					print "<p><b>Note:</b> multiple matching records found.  Only displaying the first $query_count records. After you are finished deleting these, you should perform your query again.</p>\n";
					}


print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="DeleteRecord" />
<input type="hidden" name="query_pattern" value="$html_query_pattern" />
<input type="hidden" name="Realm" value="$$p_realm_data{'name'}" />

<p>$str[274]</p>

EOM

my $x = 0;
foreach (sort @kill_us) {
	$x++;
	my $hurl = &he($_);
	print qq!<input type="checkbox" name="URL$x" value="$hurl" checked="checked" /> $hurl<br />\n!;
	}

print <<"EOM";

<p>$str[275]

<script type="text/javascript">
<!--
function ClearAll(state) {
	if (!(document && document.F1)) { return 1; }
EOM
for (1..$x) {
	print "\tif (document.F1.URL$_) {document.F1.URL$_.checked = state;}\n";
	}
print <<"EOM";
	}
document.write('<font size="-1">[ <a href="javascript:ClearAll(false)">$str[397]</a> ] [ <a href="javascript:ClearAll(true)">$str[398]</a> ]</font>');
//-->
</script>


</p>

<p><input type="submit" class="submit" value="$str[525]" /></p>

</form>

EOM

				}
			last Err;
			}


		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}





sub s_CrawlEntireSite {
	local $_;
	my ($Realm) = @_;
	my @ReIndex = ();
	my ($Count, $Limit) = (0, 2 * $Rules{'crawler: max pages per batch'});
	# limit is 2*; we send extra since URL's kicked out by first-pass filter rules aren't counted against total

	my $is_complete = 0;
	my $err = '';
	Err: {
		$FORM{'LimitFailed'} = $FORM{'LimitIndexed'} = $FORM{'LimitPending'} = 0;
		my ($obj, $p_rhandle) = ();

		$obj = &LockFile_new();
		($err, $p_rhandle) = $obj->Read('search.pending.txt');
		next Err if ($err);

		my $matchRealm = quotemeta( &url_encode($Realm) );
		my $cutTime = $FORM{'StartTime'};
		if ($FORM{'DaysPast'}) {
			$cutTime -= (86400 * $FORM{'DaysPast'});
			}

		my $qm_limit = $FORM{'LimitPattern'};
		while (defined($_ = readline($$p_rhandle))) {
			next unless (m!^(.*?) $matchRealm (\d+)!);
			my ($URL, $time) = ($1, $2);
			next unless ($URL =~ m!$qm_limit!i);
			if ($time == 2) {
				$FORM{'LimitFailed'}++;
				}
			elsif ($time >= $cutTime) {
				$FORM{'LimitIndexed'}++;
				}
			else {
				$FORM{'LimitPending'}++;
				push(@ReIndex,$URL) unless ($Count > $Limit);
				$Count++;
				}
			}
		$err = $obj->Close();
		next Err if ($err);
		unless (@ReIndex) {
			&print_AddURL_nav_header( 0, $FORM{'Action'} || '' );
			&ppstr(174, $str[276] );
			$is_complete = 1;
			last Err;
			}

		$err = &s_AddURL(0, $Realm, @ReIndex);
		next Err if ($err);

		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	return ($err, $is_complete);
	}





sub ui_Rebuild {
	my $realm = $FORM{'Realm'} || '';
	my ($err, $is_complete) = ('', 0);

	my $b_clear_err = 1;
	if ($const{'is_cmd'}) {
		$FORM{'UseTimeout'} = 0;
		delete $FORM{'LimitPattern'}; # changed 0062
		while (1) {
			($err, $is_complete) = &rebuild_realm( $realm, $b_clear_err );
			last if ($is_complete);
			$b_clear_err = 0; # don't rebuild on subsequent iterations
			last if ($err);
			}
		}
	else {
		# don't clear err if this looks like a secondary request in a multi-request rebuild...
		$b_clear_err = ((defined($FORM{'PagesDone'})) or (defined($FORM{'StartFile'}))) ? 0 : 1;
		&rebuild_realm( $realm, $b_clear_err );
		}
	}





sub rebuild_realm {
	my ($realm, $b_clear_err) = @_;
	my $is_complete = 0;
	my $err = '';
	Err: {
		local $_;
		$FORM{'LimitFailed'} = $FORM{'LimitIndexed'} = $FORM{'LimitPending'} = 0;

		if ($const{'is_cmd'}) {
			&pppstr(185, $realm );
			}
		else {
			print qq!<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> / !;
			&ppstr(185, &he($realm) );
			print "</b></p>\n";
			}

		my $p_realm_data = ();
		($err, $p_realm_data) = $realms->hashref($realm);
		next Err if ($err);

		if ($b_clear_err) {
			# clear the error cache:
			my $error_lines = 0;
			($err, $error_lines) = &clear_error_cache();
			next Err if ($err);
			}

		# What does "rebuild" mean? Well, it depends on the type of realm we're dealing with:

		my $type = $$p_realm_data{'type'};

		if ($type == 5) { # runtime realm; all dynamic data, no index; cannot rebuild
			$err = &pstr(277, $$p_realm_data{'html_name'} );
			$is_complete = 1;
			next Err;
			}
		elsif ($type == 4) { # website realm w/ file system
			if ($FORM{'DaysPast'}) {
				($err, $is_complete) = &UpdateIndex( $p_realm_data );
				}
			else {
				($err, $is_complete) = &BuildIndex( $p_realm_data );
				}
			next Err if ($err);
			last Err;
			}


		# Logic is different is we're rebuilding *all* pages or re-indexing old pages.
		# For website realms and filefed realms, a "rebuild" includes the full discovery process. A "re-index" only consists of re-indexing known pages that haven't been visited lately.
		# For "open" realms, the rebuild/re-index is essentially the same except for the time, since there is no discovery process for open realms.


		unless ($FORM{'DaysPast'}) {

			# Okay this is a "rebuild":

			if ($type == 3) {

				# a website-realm which is handled via the crawler:
				unless ($FORM{'LimitPattern'}) {
					unless ($FORM{'StartTime'}) {
						$FORM{'StartTime'} = $private{'script_start_time'} - 5;
						}

					if ($$p_realm_data{'limit_pattern'}) {
						$FORM{'LimitPattern'} = $$p_realm_data{'limit_pattern'};
						}
					else {
						$FORM{'LimitPattern'} = '^' . quotemeta(&get_web_folder($$p_realm_data{'base_url'}));
						}

					$err = &s_AddURL(0, $$p_realm_data{'name'}, $$p_realm_data{'base_url'});
					next Err if ($err);

					last Err;
					}
				($err, $is_complete) = &s_CrawlEntireSite($$p_realm_data{'name'});
				next Err if ($err);
				last Err;
				}
			}

		if ($type == 2) {
			# ahh, a filefed realm

			# 4 steps:
			# 1. request start file and extract all links
			# 2. delete all entries from search.pending.txt; replace them with new links array, using code "10"
			# 3. delete all index data
			# 4. initiate normal "index-all-old-pages" process for this realm

			unless ($FORM{'StartTime'}) {

				&pppstr(278, $$p_realm_data{'base_url'} );

				my @fresh_links = ();
				my $crawler = &Crawler_new();
				my @saved = ($Rules{'crawler: follow query strings'}, $Rules{'crawler: follow offsite links'}, $Rules{'max characters: file'}, $Rules{'crawler: rogue'});

				($Rules{'crawler: follow query strings'}, $Rules{'crawler: follow offsite links'}, $Rules{'max characters: file'},
				$Rules{'crawler: rogue'}) = (1, 1, &max($Rules{'max characters: file'},16777216),1);

				my %Response = $crawler->webrequest( 'page' => $$p_realm_data{'base_url'} );

				if ($Response{'err'}) {
					$err = $Response{'err'};
					next Err;
					}

				my %pagedata = ();

				&parse_html_ex( $Response{'text'}, $Response{'final_url'}, 1, \@fresh_links, \%pagedata);

				($Rules{'crawler: follow query strings'}, $Rules{'crawler: follow offsite links'}, $Rules{'max characters: file'}, $Rules{'crawler: rogue'}) = @saved;

				my %fresh_uniq_links = ();
				foreach (@fresh_links) {
					$fresh_uniq_links{$_}++;
					}

				@fresh_links = sort (keys %fresh_uniq_links);
				my $count = scalar @fresh_links;

				my %expired_urls = ();

				&pppstr(279, $count );

				# delete all entries:
				my ($obj, $p_rhandle, $p_whandle) = ();

				$obj = &LockFile_new(
					'create_if_needed' => 1,
					);

				my %orig_times = ();

				($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('search.pending.txt');
				next Err if ($err);

				my $i = 0;
				my $get_next = 1;
				my $file_done = 0;
				my ($u,$r,$c) = ();
				while (($file_done == 0) or ($fresh_links[$i])) {
					if (($get_next) and ($file_done == 0)) {
						if (defined($_ = readline( $$p_rhandle ))) {
							next unless (m!^(.*?) (\S+) (\d+)$!);
							($u,$r,$c) = ($1, $2, $3);
							if ($r eq $$p_realm_data{'url_name'}) {
								if ($fresh_uniq_links{$u}) {
									# still valid

									if ($FORM{'DaysPast'}) { # preserve original index times
										$orig_times{$u} = $c;
										}

									}
								else {
									$expired_urls{$u} = 1;
									}
								next;
								}
							}
						else {
							$file_done = 1;
							$_ = '';
							$u = 'z';
							}
						}
					$get_next = 1;
					if (($fresh_links[$i]) and ("$u $r" gt "$fresh_links[$i] $$p_realm_data{'url_name'}")) {

						my $timecode = defined($orig_times{$fresh_links[$i]}) ? $orig_times{$fresh_links[$i]} : 0;

						unless (print { $$p_whandle } "$fresh_links[$i] $$p_realm_data{'url_name'} $timecode\n") {
							$err = &pstr( 43, $obj->{'wname'}, $! );
							$obj->Cancel();
							next Err;
							}

						$i++;
						$get_next = 0;
						next;
						}
					unless (print { $$p_whandle } $_) {
						$err = &pstr( 43, $obj->{'wname'}, $! );
						$obj->Cancel();
						next Err;
						}
					}

				$err = $obj->Merge();
				next Err if ($err);

				# step 3 -- kill expired URL's

				if ($Rules{'sql: enable'}) {

					my $url;
					foreach $url (keys %expired_urls) {
						$err = &db_exec(
							"DELETE FROM $Rules{'sql: table name: addresses'} WHERE (realm_id = $$p_realm_data{'realm_id'}) AND (url = ?)",
							$url,
							);
						next Err if ($err);
						}
					}
				else {



					# delete all expired entries:

					my ($obj, $p_rhandle, $p_whandle) = ();

					$obj = &LockFile_new(
						'create_if_needed' => 1,
						);

					($err, $p_rhandle, $p_whandle) = $obj->ReadWrite( $$p_realm_data{'file'} );
					next Err if ($err);

					while (defined($_ = readline( $$p_rhandle ))) {
						next unless (m!^.*? u= (.*?) t=!);
						my $url = $1;
						next if ($expired_urls{$url});

						unless (print { $$p_whandle } $_) {
							$err = &pstr( 43, $obj->{'wname'}, $! );
							$obj->Cancel();
							next Err;
							}
						}

					$err = $obj->Merge();
					next Err if ($err);

					}
				}
			}

		unless ($FORM{'StartTime'}) {
			$FORM{'StartTime'} = $private{'script_start_time'} - 5;
			}

		my @list = ();
		my $count = 0;

		my $age = $FORM{'StartTime'};
		if ($FORM{'DaysPast'}) {
			$age -= (86400 * $FORM{'DaysPast'});
			}

		$err = &GetCrawlList( $$p_realm_data{'name'}, $age, 2 * $Rules{'crawler: max pages per batch'}, \@list, \$count );
		next Err if ($err);

		unless (@list) {
			# Well, we're done
			print "<p>$str[280]</p>\n";
			$is_complete = 1;
			last Err;
			}

		$err = &s_AddURL(0, $$p_realm_data{'name'}, @list );
		next Err if ($err);

		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	return ($err, $is_complete);
	}





sub GetCrawlList {
	my ( $realm, $age, $max_list_size, $p_list, $p_count) = @_;

	my $err = '';
	Err: {
		local $_;

		#&Assert( 'ARRAY' eq ref( $p_list ) );
		#&Assert( 'SCALAR' eq ref( $p_count ) );

		my ($obj, $p_rhandle) = ();
		$obj = &LockFile_new(
			'create_if_needed' => 1,
			);
		($err, $p_rhandle) = $obj->Read('search.pending.txt');
		next Err if ($err);

		my $pattern = quotemeta( &url_encode( $realm ) );

		$$p_count = 0;
		while (defined($_ = readline($$p_rhandle))) {
			next unless (m!^(.*?) $pattern (\d+)!);
			my ($URL, $time) = ($1, $2);
			if ($time == 2) {
				$FORM{'LimitFailed'}++;
				}
			elsif ($time > $age) {
				$FORM{'LimitIndexed'}++;
				}
			else {
				$FORM{'LimitPending'}++;
				push(@$p_list, $URL) if ($$p_count < $max_list_size);
				$$p_count++;
				}
			}
		$err = $obj->Close();
		next Err if ($err);
		}
	return $err;
	}





sub Authenticate {
	my ($crypt_pass) = @_;




	my ($is_auth, $form_password, $url_password) = (1, '', '');

	my $sn = &query_env('SCRIPT_NAME');

	my $seed = 'sX';

	my $test_cookie = '0';

	my $session_lifetime = 60 * $Rules{'security: session timeout'};
	my $grace_period = int($session_lifetime / 6);

	my %auth_tokens = ();

	my ($status_msg, $private_token, $public_token) = ('','','');

	if ($FORM{'CP'}) {
		$private_token = $FORM{'CP'};
		}

	my $is_cookies_aware = 0;
	my $clear_cookie = 0;

	if (&query_env('HTTP_COOKIE') =~ m!fdse_cp=([^\;]+)!) {
		$is_cookies_aware = 1;

		my $auth_cookie = &ud($1);
		if ($auth_cookie ne $test_cookie) {
			$private_token = $auth_cookie;
			}

		}


	my $b_is_api = (($ENV{'FDSE_NO_EXEC'}) and (not exists($ENV{'SERVER_SOFTWARE'})) and (not exists($ENV{'SCRIPT_NAME'})) and (not exists($ENV{'HTTP_HOST'}))) ? 1 : 0;
	if ($b_is_api) {
		$const{'is_cmd'} = 1;
		}

	my $b_print_status_only = 0;

	Auth: {
	# next for auth failure:

		# changed 0063
		if (($b_is_api) and ($private{'trust_api'})) {
			last Auth;
			}


		if (($FORM{'Action'}) and ($FORM{'Action'} eq 'LogOut')) {
			$status_msg = &pstr(174,$str[102]);
			if ($private_token) {




				my $cpass = crypt($private_token, $seed);
				if ($cpass eq '0') {
					my $temp_err_msg = "Perl crypt() function returned literal '0' - you have an incomplete Perl crypt installation. If you are running Lunix 2.2.16 with Perl 5.6.1, please upgrade with latest patches or downgrade to Perl 5.6.0";
					$status_msg = &pstr(64, "$str[282] - '$temp_err_msg'" );
					next Auth;
					}





				delete $auth_tokens{$cpass};
				&write_tokens(%auth_tokens); # no error check
				}
			next Auth;
			}


		# Is the user setting a new password? - they will still return AUTH_FAIL, but this will set the text message to an appropriate value:
		unless ($crypt_pass) {
			if (($FORM{'new_pass_1'}) or ($FORM{'new_pass_2'})) {
				$FORM{'new_pass_1'} = $FORM{'new_pass_1'} || '';
				$FORM{'new_pass_2'} = $FORM{'new_pass_2'} || '';

				$crypt_pass = 1;

				if ($FORM{'new_pass_1'} ne $FORM{'new_pass_2'}) {
					$status_msg = &pstr(64,$str[285]);
					$b_print_status_only = 1;
					next Auth;
					}

				my $cpass = crypt($FORM{'new_pass_1'}, $seed);
				if ($cpass eq '0') {
					my $temp_err_msg = "Perl crypt() function returned literal '0' - you have an incomplete Perl crypt installation. If you are running Linux 2.2.16 with Perl 5.6.1, please upgrade with latest patches or downgrade to Perl 5.6.0";
					$status_msg = &pstr(64, "$str[282] - '$temp_err_msg'" );
					$b_print_status_only = 1;
					next Auth;
					}

				my ($temp_err_msg) = &WriteRule('password', $cpass);
				if ($temp_err_msg) {
					$status_msg = &pstr(64, "$str[282] - '$temp_err_msg'" );
					$b_print_status_only = 1;
					}
				else {
					$status_msg = &pstr(174, $str[283] );
					}
				}
			next Auth;
			}

		#changed 0054 - let 'Password' override 'CP'
		if ($FORM{'Password'}) {
			if (crypt($FORM{'Password'}, $seed) ne $crypt_pass) {
				$status_msg = &pstr(64,$str[181]);
				next Auth;
				}

			# the user provided a valid password; give that man a token!

			$private_token = '';
			foreach (1..8) {
				$private_token .= chr(ord('a') + int(rand(26)));
				}



				my $cpass = crypt($private_token, $seed);
				if ($cpass eq '0') {
					my $temp_err_msg = "Perl crypt() function returned literal '0' - you have an incomplete Perl crypt installation. If you are running Lunix 2.2.16 with Perl 5.6.1, please upgrade with latest patches or downgrade to Perl 5.6.0";
					$status_msg = &pstr(64, "$str[282] - '$temp_err_msg'" );
					next Auth;
					}



			$public_token = $cpass;

			($status_msg, %auth_tokens) = &read_tokens();
			if ($status_msg) {
				$status_msg = &pstr(64, $status_msg);
				next Auth;
				}

			$auth_tokens{$public_token} = time() + $session_lifetime;

			$status_msg = &write_tokens(%auth_tokens);
			if ($status_msg) {
				$status_msg = &pstr(64, $status_msg);
				next Auth;
				}
			last Auth;
			}


		if ($private_token) {

			($status_msg, %auth_tokens) = &read_tokens();
			if ($status_msg) {
				$status_msg = &pstr(64, $status_msg);
				next Auth;
				}





				my $cpass = crypt($private_token, $seed);
				if ($cpass eq '0') {
					my $temp_err_msg = "Perl crypt() function returned literal '0' - you have an incomplete Perl crypt installation. If you are running Lunix 2.2.16 with Perl 5.6.1, please upgrade with latest patches or downgrade to Perl 5.6.0";
					$status_msg = &pstr(64, "$str[282] - '$temp_err_msg'" );
					next Auth;
					}



			$public_token = $cpass;

			unless ($auth_tokens{$public_token}) {
				$status_msg = &pstr(64, $str[281]);
				next Auth;
				}

			my $expire_time = $auth_tokens{$public_token};

			if ($expire_time < time) {

				$status_msg = '<p>' . $str[284] . '</p>';
				$clear_cookie = 1 if ($is_cookies_aware);
				next Auth;

				}
			elsif (($expire_time - $grace_period) < time) {

				# this token is about to expire; set a fresh one:

				$private_token = '';
				foreach (1..8) {
					$private_token .= chr(ord('a') + int(rand(26)));
					}




				my $cpass = crypt($private_token, $seed);
				if ($cpass eq '0') {
					my $temp_err_msg = "Perl crypt() function returned literal '0' - you have an incomplete Perl crypt installation. If you are running Lunix 2.2.16 with Perl 5.6.1, please upgrade with latest patches or downgrade to Perl 5.6.0";
					$status_msg = &pstr(64, "$str[282] - '$temp_err_msg'" );
					next Auth;
					}



				$public_token = $cpass;
				$auth_tokens{$public_token} = time() + $session_lifetime;

				$status_msg = &write_tokens(%auth_tokens);
				if ($status_msg) {
					$status_msg = &pstr(64, $status_msg);
					next Auth;
					}

				}

			last Auth;

			}



		}
	continue {

		# AUTH_FAIL

		unless ($const{'is_cmd'}) {
			print "Set-Cookie: fdse_cp=; path=$sn\015\012" if ($clear_cookie);
			print "Set-Cookie: fdse_cp=$test_cookie; path=$sn\015\012";
			print "Content-Type: text/html\015\012\015\012";

			print <<"EOM";
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
	<title>Login</title>
	<meta name="robots" content="none" />
	<meta http-equiv="Content-Type" content="$const{'content_type'}" />
	<style type="text/css">
	<!--
	.submit {
		color:#000000;
		background-color:#ffffff;
		font-weight:bold;
		cursor:pointer;
		}
	//-->
	</style>
</head>
<body dir="$const{'dir'}">
<blockquote>
<form method="post" action="$const{'script_name'}" name="F1" onsubmit="return Validate();">
<input type="hidden" name="Mode" value="Admin" />

EOM

			unless (($FORM{'Action'}) and ($FORM{'Action'} eq 'LogOut')) {
				my ($name, $value);
				while (($name, $value) = each %FORM) {
					next if ($name =~ m!^(Mode|CP|Password|new_pass_1|new_pass_2)$!);
					$value = &he($value);
					print qq!<input type="hidden" name="$name" value="$value" />\n!;
					}
				}

			}

		my %replace = (
			'html_status_msg' => $status_msg,
			'pass_value' => $const{'is_demo'} ? 'password' : '',
			);

		unless ($crypt_pass) {
			if ($b_is_api) {
				print "Password not yet defined.  Must be set via web-based interface.\n";
				}
			else {
				&PrintTemplate( 0, 'admin_pass2.txt', $Rules{'language'}, \%replace );
				}
			}
		elsif (($const{'is_cmd'}) or ($b_print_status_only)) {
			print $status_msg;
			}
		else {
			&PrintTemplate( 0, 'admin_pass1.txt', $Rules{'language'}, \%replace );
			&pppstr( 493, $const{'help_file'} );
			}

print <<"FOOTER" unless ($const{'is_cmd'});

</form>
<script type="text/javascript">
<!--
if ((document) && (document.F1) && (document.F1.Password)) {
	document.F1.Password.focus();
	}
function Validate() {
	if (!((document) && (document.F1) && (document.F1.new_pass_1) && (document.F1.new_pass_2))) {
		return true;
		}
	if (document.F1.new_pass_1.value != document.F1.new_pass_2.value) {
		alert("$str[73]: $str[285].");
		return false;
		}
	else if (document.F1.new_pass_1.value.length == 0) {
		alert("$str[73]: $str[286].");
		return false;
		}
	return true;
	}
// -->
</script>
<p>Fluid Dynamics Search Engine v$VERSION</p>
</blockquote>
</body>
</html>

FOOTER
		$is_auth = 0;
		}
	if ($is_auth) {
		if ($is_cookies_aware) {
			print "Set-Cookie: fdse_cp=" . &url_encode($private_token) . "; path=$sn\015\012";
			}
		else {
			$url_password = "&amp;CP=" . &url_encode($private_token);
			$form_password = '<input type="hidden" name="CP" value="' . &he($private_token) . '" />';
			}
		}
	return ($is_auth, $form_password, $url_password);
	}





sub read_tokens {
	my %tokens = ();
	my $err = '';
	Err: {
		local $_;
		my $text = '';
		if (-e 'auth_tokens.txt') {
			($err, $text) = &ReadFile('auth_tokens.txt');
			next Err if ($err);
			}
		foreach (split(m!\015\012!s, $text)) {
			next unless (m!Token: (\S+); Expires: (\d+)!);
			$tokens{$1} = $2;
			}
		}
	return ($err,%tokens);
	}





sub write_tokens {
	my %tokens = @_;
	my $text = '';
	my ($token, $expires) = ();
	while (($token, $expires) = each %tokens) {
		next if ($expires < time());
		$text .= "Token: $token; Expires: $expires\015\012";
		}
	return &WriteFile('auth_tokens.txt', $text);
	}





sub WriteRule {
	my $name = $_[0];
	my $value = defined($_[1]) ? $_[1] : 0;
	my $err = '';
	Err: {
		last Err if ($Rules{$name} eq $value);

		my $FDR = &FD_Rules_new();

		my ($is_valid, $valid_value) = $FDR->_fdr_validate($name, $value);
		unless ($is_valid) {
			$err = &pstr(170,&he($name,$value));
			next Err;
			}

		$valid_value =~ s!(\r|\n|\015|\012)! !sg; # all line breaks become spaces

		my $obj = &LockFile_new(
			'create_if_needed' => 1,
			);
		my ($p_rhandle, $p_whandle) = ();
		($err, $p_rhandle, $p_whandle) = $obj->ReadWrite($FDR->{'file'});
		next Err if ($err);

		my $qm_name = quotemeta($name);

		local $_;
		while (defined($_ = readline($$p_rhandle))) {
			next if (m!^\s*$qm_name\s*=!i);
			unless (print { $$p_whandle } $_) {
				$err = &pstr( 43, $FDR->{'file'}, $! );
				$obj->Cancel();
				next Err;
				}
			}
		unless (print { $$p_whandle } "\015\012$name = $valid_value\015\012") {
				$err = &pstr( 43, $FDR->{'file'}, $! );
				$obj->Cancel();
				next Err;
				}
		$err = $obj->Merge();
		next Err if ($err);
		$Rules{$name} = $valid_value;
		}
	return $err;
	}





sub clear_error_cache {
	my $error_lines = 0;
	my $err = '';
	Err: {
		my ($obj, $p_rhandle, $p_whandle) = ();
		$obj = &LockFile_new(
			'create_if_needed' => 1,
			);
		($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('search.pending.txt');
		next Err if ($err);
		while (defined($_ = readline($$p_rhandle))) {
			if (m! 2$!) {
				$error_lines++;
				next;
				}
			unless (print { $$p_whandle } $_) {
				$err = &pstr(43,$obj->get_wname(),$!);
				$obj->Cancel();
				next Err;
				}
			}
		$err = $obj->Merge();
		next Err if ($err);
		last Err;
		}
	return ($err, $error_lines);
	}





sub ui_DataStorage {

	my $dbh = undef();
	my $sth = undef();

	my $err = '';
	Err: {

print <<"EOM";

		<p><b><a href="$const{'admin_url'}" target="_top">$str[96]</a> /
			<a href="$const{'admin_url'}&amp;Action=manage_data_storage">$str[292]</a>

EOM

		my $status_msg = '';

		my $is_error = 0;

		my $subaction = $FORM{'subaction'} || '';

		if ($subaction eq 'create_log') {
			print " / Create Log</b></p>";
			$err = &create_sql_log();
			next Err if ($err);
			&ppstr(174, &pstr(293, $Rules{'sql: table name: logs'} ) );
			last Err;
			}

		if ($subaction eq 'ClearError') {
			print " / $str[332]</b></p>\n";
			my $error_lines = 0;
			($err, $error_lines) = &clear_error_cache();
			next Err if ($err);
			&ppstr(174, &pstr(178,$error_lines,'search.pending.txt'));
			last Err;
			}

		if ($subaction eq 'ReviewPending') {

			print " / <a href=\"$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=ReviewPending\">$str[294]</a></b></p>\n";

			my %valid_realms = ();
			my %true_count = ();
			my %err_count = ();

			my $error_count = 0;
			my $total_count = 0;

			my %kill_waiting = ();

			my %wait_count = ();
			my $p_realm_data = ();
			foreach $p_realm_data ($realms->listrealms('all')) {
				my ($count, $url_name, $html_name) = ($$p_realm_data{'pagecount'}, &url_encode($$p_realm_data{'name'}), &he($$p_realm_data{'name'}));
				$valid_realms{$url_name} = $count;
				$true_count{$url_name} = 0;
				$wait_count{$url_name} = 0;
				$err_count{$url_name} = 0;
				$kill_waiting{$url_name} = ($$p_realm_data{'type'} == 3) ? 0 : 1;
				}

			my ($obj, $p_rhandle, $p_whandle) = ();

			$obj = &LockFile_new(
				'create_if_needed' => 1,
				);
			($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('search.pending.txt');
			next Err if ($err);

			my $invalid_lines = 0;
			my $old_realms = 0;

			my $prev_url = '';
			local $_;
			while (defined($_ = readline($$p_rhandle))) {
				unless (m!^http://(.*) (\S+) (\d+)\r?$!) {
					next;
					}
				my ($url, $realm, $time) = ("http://$1", $2, $3);
				if ($time == 2) {
					$error_count++;
					$err_count{$realm}++;
					}
				else {
					unless ($valid_realms{$realm}) {
						$realm = &he( &ud( $realm ) );
						&ppstr(53, &pstr(295, $realm ) );
						$old_realms++;
						next;
						}
					elsif (($time == 0) and ($kill_waiting{$realm})) {
						next;
						}
					if ($url lt $prev_url) {
						&ppstr(53, $str[296] );
						&pppstr(297, $url, $prev_url );
						next;
						}
					$true_count{$realm}++ if ($time > 10);
					$wait_count{$realm}++ if ($time == 0);
					}
				$total_count++;
				$prev_url = $url;
				print { $$p_whandle } $_;
				}
			$err = $obj->Merge();
			next Err if ($err);

			if ($invalid_lines) {
				&pppstr(298, $invalid_lines );
				}
			if ($old_realms) {
				&pppstr(299, $old_realms );
				}

			&ppstr(174, $str[499] );
			&pppstr(301, $total_count, $error_count );


print <<"EOM";
<table border="1" cellpadding="4" cellspacing="1">
<tr>
	<th>$str[428]</th>
	<th>$str[146]</th>
	<th>$str[302]</th>
	<th>$str[303]</th>
	<th>$str[304]</th>
	<th>$str[305]</th>
</tr>
EOM

			my ($name, $pagecount, $truecount) = ();
			while (($name, $pagecount) = each %valid_realms) {
				my $truecount = $true_count{$name};
				my $realm = &he( &ud( $name ) );

print <<"EOM";

<tr class="fdtan">
	<td>$realm</td>
	<td align="center">
		<a href="$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=sync&amp;Realm=$name" class="onbrown">$str[306]</a> |
		<a href="$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=rmdupe&amp;Realm=$name" class="onbrown">$str[307]</a>
		</td>
	<td align="right">$truecount</td>
	<td align="right">$pagecount</td>
	<td align="right">$wait_count{$name}</td>
	<td align="right">$err_count{$name}</td>
</tr>

EOM
				}

print <<"EOM";
</table>

<p><b>$str[63]:</b></p>

$str[308]

EOM
			last Err;
			}



		if ($subaction eq 'rmdupe') {
			print " / <a href=\"$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=ReviewPending\">$str[294]</a> / $str[307]</b></p>\n";

			my $p_realm_data = ();
			($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
			next Err if ($err);

			if ($$p_realm_data{'is_runtime'}) {
				$err = &pstr(277, $$p_realm_data{'html_name'} );
				next Err;
				}

			if ($Rules{'sql: enable'}) {
				$err = $str[309];
				next Err;
				}


			# Get a list of all pages in the realm - import them into the pending file
			my %crawler_results = ();

			my $count = 0;
			my $dupes = 0;

			my ($obj, $p_rhandle, $p_whandle) = ();


			my %pages = ();

			$obj = &LockFile_new(
				'create_if_needed' => 1,
				);

			($err, $p_rhandle, $p_whandle) = $obj->ReadWrite( $$p_realm_data{'file'} );
			next Err if ($err);

			while (defined($_ = readline( $$p_rhandle ))) {
				next unless (m! u= (.+?) t=!);
				if ($pages{$1}) {
					&pppstr(310, $1 );
					$dupes++;
					}
				else {
					$count++;
					print { $$p_whandle } $_;
					}
				$pages{$1}++;
				}
			$err = $obj->Merge();
			next Err if ($err);

			&pppstr(311, $dupes );
			&pppstr(313, $$p_realm_data{'html_name'}, $count );

			$err = $realms->setpagecount( $$p_realm_data{'name'}, $count, 1);
			next Err if ($err);

			last Err;
			}



		if ($subaction eq 'sync') {
			print " / <a href=\"$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=ReviewPending\">$str[294]</a> / $str[306]</b></p>\n";

			my $p_realm_data = ();
			($err, $p_realm_data) = $realms->hashref($FORM{'Realm'});
			next Err if ($err);

			my $url_realm = $$p_realm_data{'url_name'};

			if ($$p_realm_data{'is_runtime'}) {
				$err = &pstr(277, $$p_realm_data{'html_name'} );
				next Err;
				}

			# Get a list of all pages in the realm - import them into the pending file
			my %crawler_results = ();

			my $count = 0;

			my ($obj, $p_rhandle, $p_whandle) = ();

			my %valid = ( 'is_error' => 0 );
			if ($Rules{'sql: enable'}) {

				$err = &get_dbh( \$dbh );
				next Err if ($err);

				unless ($sth = $dbh->prepare("SELECT url FROM $Rules{'sql: table name: addresses'} WHERE realm_id = $$p_realm_data{'realm_id'}")) {
					$err = $str[45] . ' ' . $dbh->errstr();
					next Err;
					}
				unless ($sth->execute()) {
					$err = $str[29] . ' ' . $sth->errstr();
					next Err;
					}
				my $url = '';
				while (($url) = $sth->fetchrow_array()) {
					if ($crawler_results{$url}) {
						&ppstr(53, $str[317] );
						}
					else {
						$crawler_results{$url} = \%valid;
						}
					$count++;
					}
				$sth->finish();
				$sth = undef();
				$dbh->disconnect();
				$dbh = undef();
				}
			else {

				$obj = &LockFile_new(
					'create_if_needed' => 1,
					);

				($err, $p_rhandle) = $obj->Read( $$p_realm_data{'file'} );
				next Err if ($err);

				while (defined($_ = readline( $$p_rhandle ))) {
					next unless (m! u= (.+?) t=!);
					if ($crawler_results{$1}) {
						&ppstr(53, $str[317] );
						&pppstr(318);
						}
					else {
						$crawler_results{$1} = \%valid;
						}
					$count++;
					}
				$err = $obj->Close();
				next Err if ($err);
				}

			print "<p>$str[319]</p>\n";
			foreach (sort keys %crawler_results) {
				print &he($_) . "<br />\n";
				}
			$obj = &LockFile_new(
				'create_if_needed' => 1,
				);
			($err, $p_rhandle, $p_whandle) = $obj->ReadWrite('search.pending.txt');
			next Err if ($err);

			while (defined($_ = readline( $$p_rhandle ))) {
				if (m!^(.*) $url_realm (\d+)$!) {
					my ($url, $code) = ($1, $2);
					if ($code > 2) {
						unless ($crawler_results{$url}) {
							&ppstr( 316 , &he($url) );
							print "<br />\n";
							}
						next;
						}
					}
				print { $$p_whandle } $_;#TODO
				}

			$err = $obj->Merge();
			next Err if ($err);

			$err = &SaveLinksToFileEx( $p_realm_data, \%crawler_results );
			next Err if ($err);

			&pppstr(313, $$p_realm_data{'html_name'}, $count );

			$err = $realms->setpagecount( $$p_realm_data{'name'}, $count, 1);
			next Err if ($err);

			last Err;
			}


#db
		if ($subaction eq 'create') {
			print " / Create tables</b></p>\n";

			$err = &create_db_config(1, 1);
			if ($err) {
				&ppstr(64, $str[315] );
				print $err;
				}
			else {
				&ppstr(174, $str[314] );
				}
			last Err;
			}


		if ($subaction eq 'set_log_type') {

			print " / $str[362]</b></p>\n";

			$err = &WriteRule('sql: logfile', ($FORM{'datastor'} eq 'db') ? 1 : 0);
			next Err if ($err);
			&ppstr(174, &pstr(320, $FORM{'datastor'} ) );
			last Err;
			}

		if ($subaction eq 'set_type') {
			print " / $str[362]</b></p>\n";

			$err = &WriteRule('sql: enable', ($FORM{'datastor'} eq 'db') ? 1 : 0);
			next Err if ($err);

			&ppstr(174, &pstr(321, $FORM{'datastor'} ) );
			print "<p>$str[322]</p>\n";
			last Err;
			}


		if ($subaction eq 'migrate') {
			print " / $str[323]</b></p>\n";

			# Migrate realms:

			if ($FORM{'dir'} eq 'sql_to_file') {

				$realms->use_database(1);
				$err = $realms->load();
				next Err if ($err);

				# all in memory now.

				$realms->use_database(0);
				$err = $realms->save_realm_data();
				next Err if ($err);
				&pppstr(324, $Rules{'sql: table name: realms'} );
				}
			else {
				$realms->use_database(0);
				$err = $realms->load();
				next Err if ($err);

				# all in memory now.

				$realms->use_database(1);
				$err = $realms->save_realm_data();
				next Err if ($err);
				&pppstr(325, $Rules{'sql: table name: realms'} );
				}

			# At this point, all the realm data is sync'ed. Force a second load from the database, to make sure that the realm_id variables are non-trivial:
			$realms->use_database(1);
			$err = $realms->load();
			next Err if ($err);

			my $p_realm_data = ();
			foreach $p_realm_data ($realms->listrealms('all')) {

				my $realm_id = $$p_realm_data{'realm_id'};
				my $realm_name = $$p_realm_data{'name'};

				my $file = $$p_realm_data{'file'};

				print "<p>Migrating data for realm '$realm_name' ($FORM{'dir'})...</p>\n";


				# Kill existing data:

				if ($FORM{'dir'} eq 'file_to_sql') {

					# Kill SQL data:

					$err = &get_dbh(\$dbh);
					next Err if ($err);
					unless ($sth = $dbh->prepare("DELETE FROM $Rules{'sql: table name: addresses'} WHERE realm_id = $realm_id")) {
						$err = $str[45] . ' ' . $dbh->errstr();
						next Err;
						}
					unless ($sth->execute()) {
						$err = $str[29] . ' ' . $sth->errstr();
						next Err;
						}
					$sth->finish();
					$sth = undef();
					$dbh->disconnect();
					$dbh = undef();
					}

				else {
					# Kill file data:
					$err = &WriteFile( $file, '' );
					next Err if ($err);
					}


				my $start_pos = 0;
				my $increment = 50;

				my ($total_records, $new_records, $updated_records, $deleted_records);

				while (1) {

					my %crawler_results = ();

					# Pull in 50 records from the old data store:

					if ($FORM{'dir'} eq 'file_to_sql') {
						$err = &query_file( $realm_name, '', $start_pos, $increment, \%crawler_results );
						}
					else {
						$err = &query_database( $realm_name, '', $start_pos, $increment, \%crawler_results );
						}
					next Err if ($err);

					# Are we out of records? If so, %crawler_results will be the empty set:
					last unless (%crawler_results);

					&pppstr(326, $realm_name, $start_pos, $start_pos + $increment );
					print "<blockquote>\n";
					while (defined($_ = each %crawler_results)) {

						my $p_pagedata = $crawler_results{$_};

						if (not ($$p_pagedata{'realm_id'})) {
							if ($realm_id) {
								$$p_pagedata{'realm_id'} = $realm_id;
								}
							}
						unless ($$p_pagedata{'lastmodtime'}) {
							$$p_pagedata{'lastmodtime'} = time();
							}


						my ($temp_err_msg, $text_record) = &text_record_from_hash( $p_pagedata );
						if ($temp_err_msg) {
							print "<b>$str[73]:</b> - $str[327] -$temp_err_msg - $_<br />\n";
							}
						else {
							print "$_<br />\n";
							$$p_pagedata{'record'} = $text_record;
							}
						}
					print "</blockquote>\n";


					# Write those 50 records into the new data store:

					if ($FORM{'dir'} eq 'file_to_sql') {
						($err, $total_records, $new_records, $updated_records, $deleted_records) = &update_database( $realm_name, \%crawler_results );
						}
					else {
						($err, $total_records, $new_records, $updated_records, $deleted_records) = &update_file( $realm_name, \%crawler_results );
						}

					next Err if ($err);

					&pppstr(289, $realm_name, $total_records, $new_records, $updated_records, $deleted_records );

					$start_pos += $increment;

					}
				&pppstr(328, $realm_name );
				print "<p>$str[329]</p>\n";
				}
			&ppstr(174, $str[330] );

			if ($FORM{'dir'} eq 'file_to_sql') {
				print $str[331];
				}

			last Err;
			}

#/db

		print " / $str[152]</b></p>"; # Finish toplink

print <<"EOM";

<p><b>$str[333]</b></p>
<ul>
	<li><a href="$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=ReviewPending">$str[294]</a> - $str[334]</li>
	<li><a href="$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=ClearError">$str[332]</a> - $str[335]</li>
</ul>

EOM

#db

print <<"EOM";

<p><b>$str[336]</b></p>
<blockquote>

EOM

		Test: {

			# load the DBI

			my %rq_mods = (
				'DBI' => 0.9,
				'DBD::mysql' => 1,
				);

			my $mod = ();
			foreach $mod ('DBI', 'DBD::mysql') {
				my $dbiver = 0;
				my $code = 'use ' . $mod . '; $dbiver = $' . $mod . '::VERSION; ';
				eval $code;
				if ($@) {
					$status_msg = &pstr(22, $mod, $@ );
					undef($@);
					next Test;
					}
				elsif ($dbiver < $rq_mods{$mod}) {
					$status_msg = &pstr(23, $mod, $dbiver, $rq_mods{$mod} );
					next Test;
					}
				&ppstr(174, &pstr(337, $mod, $dbiver ) );
				}


			last;
			}
		continue {
			$is_error = 1;

			print "<p>$str[491]</p>\n";
			print "</blockquote>";

			print "<!-- ";
			&ppstr(53, $status_msg );
			print " -->";

			last Err;
			}

print <<"EOM";

	</blockquote>

	<p><b>$str[338]</b></p>
	<blockquote>

		<p>Note: all mysql code will be removed from FDSE in an upcoming future release. Please use the file system storage method instead (which is the default configuration.)</p>

		<p>In the far future, the mysql code may be re-written and added back in, but in the meantime the current mysql code is slower and has many bugs.</p>

EOM

	if ($is_error) {
		print "<p>$str[339]</p>\n";
		}
	else {
		&ui_GeneralRules( $str[292], 'manage_data_storage', 'sql: hostname', 'sql: database', 'sql: username', 'sql: password' );

print <<"EOM";

	</blockquote>

	<p><b>$str[344]</b></p>

	<blockquote>

		<p>$str[345]</p>

EOM
		&ui_GeneralRules( $str[292], 'manage_data_storage', 'sql: table name: realms', 'sql: table name: addresses', 'sql: table name: logs' );
		}



print <<"EOM";

	</blockquote>

	<p><b>$str[340]</b></p>
	<blockquote>

EOM

	my ($addr_count, $realmcount, $log_exists) = (0, 0, 0);

	Test: {

		if ($is_error) {
			print "<p>$str[339]</p>\n";
			last Test;
			}

		my @need_init = ();
		foreach ('database', 'hostname', 'password', 'username') {
			unless ($Rules{"sql: $_"}) {
				push(@need_init, "sql: $_");
				}
			}
		if (@need_init) {
			$status_msg = "$str[341] '" . join("', '", @need_init) . "'";
			next Test;
			}

		#TODO: resolve error handling
		($status_msg, $addr_count, $realmcount, $log_exists) = &check_db_config(1);
		if ($status_msg) {
			print $status_msg;
			$status_msg = '';
			}

		&ppstr(174, &pstr(342, $Rules{'sql: database'}, $addr_count, $realmcount ) );

		&pppstr(346, "<a href=\"$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=create\" onclick=\"return confirm('$str[109]');\">$str[193]</a>", $Rules{'sql: database'} );

		print "<p><b>$str[343]</b></p>\n";

		if ($Rules{'sql: table name: logs'}) {

			if ($log_exists) {
				&ppstr(174, "log table '$Rules{'sql: table name: logs'}' is configured properly" );
				}
			else {
				&ppstr(53, "log table '$Rules{'sql: table name: logs'}' does not exist" );
				}

			&pppstr(347, qq!<a href="$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=create_log" onclick="return confirm('$str[109]');">$str[193]</a>!, $Rules{'sql: table name: logs'} );

			}
		else {
			print "<p>$str[348]</p>\n";
			}

		last Test
		}
	continue {
		&ppstr(53, $status_msg );
		$is_error = 1;
		}

print <<"EOM";

	</blockquote>

	<p><b>$str[323]</b></p>
	<blockquote>

EOM

	if ($is_error) {
		print "<p>$str[339]</p>\n";
		}
	else {

print <<"EOM";

		<p><a href="$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=migrate&amp;dir=sql_to_file"><b>$str[349]</b></a></p>

		<p>$str[351]</p>

		<p><a href="$const{'admin_url'}&amp;Action=manage_data_storage&amp;subaction=migrate&amp;dir=file_to_sql"><b>$str[350]</b></a></p>

		<p>$str[352]</p>

EOM
	}


my $data_stor = '';
my @def = ();

if ($Rules{'sql: enable'}) {
	@def = ('', ' CHECKED');
	$data_stor = 'database';
	}
else {
	@def = (' CHECKED', '');
	$data_stor = 'file system';
	}

print <<"EOM";

	</blockquote>

	<p><b>$str[353]</b></p>
	<blockquote>

		<p>$str[354] $data_stor</p>

EOM

	if (($is_error) and (not $Rules{'sql: enable'})) {
		# do nothing
		}
	else {

		if (($is_error) and ($Rules{'sql: enable'})) {
			print "<p>$str[355]</p>\n";
			}


print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="manage_data_storage" />
<input type="hidden" name="subaction" value="set_type" />


		<p><input type="radio" name="datastor" value="fs"$def[0] /> $str[356]</p>
		<p><input type="radio" name="datastor" value="db"$def[1] /> $str[357]</p>

		<p><input type="submit" class="submit" value="$str[362]" /></p>
		</form>
EOM
	}


$data_stor = '';
@def = ();

if ($Rules{'sql: logfile'}) {
	@def = ('', ' CHECKED');
	$data_stor = 'database';
	}
else {
	@def = (' CHECKED', '');
	$data_stor = 'file system';
	}

print <<"EOM";

	</blockquote>

	<p><b>$str[358]</b></p>
	<blockquote>

		<p>$str[354] $data_stor</p>


EOM

	if (($is_error) and (not $Rules{'sql: logfile'})) {
		# do nothing
		}
	else {

		if (($is_error) and ($Rules{'sql: logfile'})) {
			print "<p>$str[355]</p>\n";
			}

print <<"EOM";

$const{'AdminForm'}
<input type="hidden" name="Action" value="manage_data_storage" />
<input type="hidden" name="subaction" value="set_log_type" />

		<p><input type="radio" name="datastor" value="fs"$def[0] /> $str[356]</p>
		<p><input type="radio" name="datastor" value="db"$def[1] /> $str[357]</p>

		<p><input type="submit" class="submit" value="$str[362]" /></p>
		</form>
EOM
	}

print <<"EOM";

	</blockquote>

EOM

#/db

		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	$sth->finish() if ($sth);
	$dbh->disconnect() if ($dbh);
	}





sub CheckEmail {
	my ($address) = @_;
	my $err = '';
	Err: {
		unless ($address) {
			$err = $str[359];
			next Err;
			}

		unless ($address =~ m!^(.+?)\@(.+?)$!) {
			$err = &pstr(360, $address );
			next Err;
			}

		}
	return $err;
	}





sub SendMailEx {
	my %params = @_;
	my $basename = '';
	my $full_message = '';
	my $trace = '';
	my $err = '';
	Err: {
		local $_;

		my $p_nc_cache = ();
		if ($params{'p_nc_cache'}) {
			$p_nc_cache = $params{'p_nc_cache'};
			}
		else {
			my %nc_cache = ();
			$p_nc_cache = \%nc_cache;
			}


		# validate inputs:
		if ((not $params{'to name'}) and ($params{'to_name'})) {
			$params{'to name'} = $params{'to_name'};
			}
		if ((not $params{'from name'}) and ($params{'from_name'})) {
			$params{'from name'} = $params{'from_name'};
			}
		if ((not $params{'message'}) and ($params{'body'})) {
			$params{'message'} = $params{'body'};
			}

		foreach ('to', 'from') {
			unless ($params{$_}) {
				$err = &pstr(21,$_);
				next Err;
				}
			}

		$params{'port'} = 25 unless ($params{'port'});

		# build the full message:

		$full_message = '';


		if ($params{'raw'}) {
			$full_message = $params{'raw'};
			}
		else {
			$full_message = &sendmail_build_raw_message($params{'to'},$params{'to name'},$params{'from'},$params{'from name'},$params{'subject'},$params{'message'},$params{'is_html'});
			}

		# Fix for bare LF

		$full_message =~ s!\015\012!\012!sg;
		$full_message =~ s!\015!\012!sg;
		$full_message =~ s!\012!\015\012!sg;


		# Escape any literal CRLF . CRLF sequences (this is the end-of-message sequence in SMTP)
		$full_message =~ s!\015\012\.\015\012!\015\012\. \015\012!sg;

		# Message has been built - now send it:

		my %hosts_tried = ();

		my $b_message_sent = 0;

		$params{'handler_order'} = '12345' unless (defined($params{'handler_order'}));
		TryToSend: foreach (split(m!!, $params{'handler_order'})) {
			next TryToSend unless (m!^\d$!);

			if (($_ == 1) and ($params{'pipeto'})) {
				if (open(PIPE, "|$params{'pipeto'} -t")) {
					binmode(PIPE);
					$full_message =~ s!\015\012!\012!sg; # Unix-friendly for Unix
					print PIPE $full_message;
					close(PIPE);
					$trace = $full_message;
					$b_message_sent = 1;
					last TryToSend;
					}
				$err = &pstr(440, $params{'pipeto'}, $!);
				next TryToSend;
				}

			if (($_ == 2) and ($params{'host'})) {
				next if ($hosts_tried{$params{'host'}});
				($err, $trace) = &sendmail_socket( $params{'host'}, $params{'port'}, $params{'to'}, $params{'from'}, $full_message, $p_nc_cache, $params{'use standard io'} );
				$hosts_tried{$params{'host'}} = 1;
				next TryToSend if ($err);
				$b_message_sent = 1;
				last TryToSend;
				}
			}
		if ((not $b_message_sent) and (not $err)) {
			$err = $str[445];
			last Err;
			}
		}
	return ($err, $trace);
	}





sub sendmail_build_raw_message {
	my ($to_addr,$to_name,$from_addr,$from_name,$subject,$body,$is_html) = @_;
	my $raw_message = '';

	if ($to_name) {
		$raw_message .= qq!To: "$to_name" <$to_addr>\015\012!;
		}
	else {
		$raw_message .= "To: $to_addr\015\012";
		}


	if ($from_name) {
		$raw_message .= qq!From: "$from_name" <$from_addr>\015\012!;
		}
	else {
		$raw_message .= "From: $from_addr\015\012";
		}


	$raw_message .= "Subject: $subject\015\012";
	$raw_message .= "Date: " . &sendmail_datetime(time()) . "\015\012";


	if ($is_html) {
		$raw_message .= "Content-Type: text/html\015\012";
		}
	$raw_message .= "\015\012";
	$raw_message .= $body;
	return $raw_message;
	}





sub sendmail_socket {
	my ($host,$port,$to,$from,$raw,$p_nc_cache,$b_use_standard_io) = @_;
	my $is_open = 0;
	my $trace = '';
	my $err = '';
	Err: {
		# connect to the SMTP server
		$err = &leansock($host,$port,\*MAIL,$p_nc_cache);
		next Err if ($err);
		$is_open = 1;
		my @commands = (
			[ 'Welcome',
				220, 0, '',
				],
			[ 'HELO',
				250, 1, "HELO $host",
				],
			[ 'Mail From',
				250, 1, "MAIL FROM:<$from>",
				],
			[ 'Recipient/To',
				250, 1, "RCPT TO:<$to>",
				],
			[ 'Data Initialize',
				354, 1, "DATA",
				],
			[ 'Data Transfer',
				250, 1, "$raw\015\012.\015\012",
				],
			);
		my $i = 0;
		for ($i = 0; $i <= $#commands; $i++) {
			my ($expect_code, $sendrecv, $send_data) = ($commands[$i][1], $commands[$i][2], $commands[$i][3]);
			if ($sendrecv) {
				$send_data .= "\015\012";
				my $data_len = length($send_data);
				my $send_len = 0;
				if ($b_use_standard_io) {
					$send_len = send(*MAIL, $send_data, 0);
					}
				else {
					$send_len = syswrite(*MAIL, $send_data, $data_len);
					}
				unless (defined($send_len)) {
					$err = &pstr(452,"$! - $^E");
					next Err;
					}
				if ($send_len != $data_len) {
					$err = &pstr(452, &pstr(453, $send_len, $data_len) . " - $! - $^E");
					next Err;
					}
				$trace .= $send_data;
				}

			next unless ($b_use_standard_io);

			my $response_code = '';
			my $response_text = '';
			local $_;
			while (defined($_ = readline(*MAIL))) {
				$response_text .= $_;
				$trace .= $_;
				s!(\r|\n|\015|\012)!!g;#correct for MacPerl
				if ((m!^(\d\d\d)\-!) and ($1 ne '000')) {
					$response_code = $1 unless ($response_code);
					}
				elsif (m!^(\d\d\d)\r?(\s|$)!) {
					$response_code = $1 unless ($response_code);
					last;
					}
				else {
					$err = &pstr(448, "$host:$port", $commands[$i][0], $response_text);
					next Err;
					}
				}
			unless ($response_code =~ m!$expect_code!) {
				$err = &pstr(449, "$host:$port", $commands[$i][0], $expect_code, $response_code, $response_text);
				next Err;
				}

			}
		}
	close(*MAIL) if ($is_open);
	return ($err, $trace);
	}





sub leansock {
	my ($host,$port,$p_socket,$p_nc_cache) = @_;
	my $err = '';
	Err: {
		$host = lc($host);
		unless (defined($$p_nc_cache{"H:$host"})) {
			$$p_nc_cache{"H:$host"} = (gethostbyname($host))[4];
			}
		my $addr = $$p_nc_cache{"H:$host"};
		unless ($addr) {
			$err = &pstr(436, $host, $!, $^E);
			next Err;
			}
		#optout use Socket;
		eval 'use Socket;';
		if ($@) {
			$err = &pstr(22, 'Socket', $@ );
			undef($@);
			next Err;
			}
		#/optout
		unless (socket($$p_socket, &PF_INET(), &SOCK_STREAM(), scalar getprotobyname('tcp'))) {
			$err = &pstr(437, $!, $^E);
			next Err;
			}
		unless (connect($$p_socket, sockaddr_in($port,$addr))) {
			$err = &pstr(438,$host,$port,$!,$^E);
			close($$p_socket);
			next Err;
			}
		unless (binmode($$p_socket)) {
			$err = &pstr(439,$!,$^E);
			close($$p_socket);
			next Err;
			}
		my $h = select($$p_socket);
		$| = 1;
		select($h);
		}
	return $err;
	}





sub sendmail_datetime {
	local $_;
	my ($time_int) = @_;
	my ($sec, $min, $milhour, $day, $month_int, $year, $weekday_int) = gmtime($time_int);
	$year += 1900;
	foreach ($milhour, $min, $sec, $day) {
		$_ = "0$_" if (1 == length($_));
		}
	my $month_str = ('Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec')[$month_int];
	my $weekday_str = ('Sun','Mon','Tue','Wed','Thu','Fri','Sat')[$weekday_int];
	return "$weekday_str, $day $month_str $year $milhour:$min:$sec -0000";
	}





sub Crawler_new {
	my $self = {
		'b_use_proxy' => 0,
		'proxy_addr' => 'proxy',
		'proxy_port' => 80,
		};
	bless($self);

	my %cookies = ();
	my %robot_files = ();

	$self->{'p_cookies'} = \%cookies;
	$self->{'p_robot_files'} = \%robot_files;

	return $self;
	}





sub webrequest {
	my ($self, %request) = @_;
	my @redirects = ();
	my %webrq = (
		'err' => '',
		'final_url' => '',
		'total_requests' => 0,
		'text' => '',
		'no_index_but_follow' => 0,
		'no_follow' => 0,
		'lastmodt' => 0,
		'ref_redirects' => \@redirects,
		);

	my $current_url = $request{'page'};

	my ($host,$port,$path,$query);

	my $err = '';
	Err: {

		my $max_redirects = $Rules{'crawler: max redirects'};

		my %rawrq = ();

		FollowRedirects: while ($webrq{'total_requests'} <= (1 + $max_redirects)) {

			$webrq{'total_requests'}++;

			($err,$current_url,$host,$port,$path,$query) = &uri_parse($current_url);
			next Err if ($err);

			$path = $path . $query; # for our purposes here

			$webrq{'final_url'} = $current_url;

			push(@redirects, $current_url);
			if (($request{'limit'}) and ($current_url !~ m!$request{'limit'}!i)) {
				$err = &pstr(376,&he($current_url,$request{'limit'}));
				next Err;
				}

			unless ($Rules{'crawler: rogue'}) {
				my $RobotFile = "http://$host:$port/robots.txt";
				my $p_robot_files = $self->{'p_robot_files'};
				unless (defined($$p_robot_files{$RobotFile})) {
					my @forbidden_paths = ();
					my %rawrq = $self->raw_get($host, $port, '/robots.txt', 'GET', '', '');
					unless ($rawrq{'err'}) {
						foreach (&ParseRobotFile($rawrq{'text'}, $Rules{'crawler: user agent'})) {
							push(@forbidden_paths, quotemeta($_));
							}
						}
					$$p_robot_files{$RobotFile} = \@forbidden_paths;
					}
				my $ref_forbidden_paths = $$p_robot_files{$RobotFile};
				foreach (@$ref_forbidden_paths) {
					if ($path =~ m!^$_!) {
						$RobotFile =~ s!^http://([^/]+):80/!http://$1/!o;
						$err = &pstr(90,$RobotFile,&he($path));
						next Err;
						}
					}
				}
			%rawrq = $self->raw_get($host, $port, $path);

			if ($rawrq{'err'}) {
				if ($rawrq{'is_redirect'}) {
					$webrq{'total_requests'}++;
					push(@redirects, $rawrq{'location'});
					}
				$err = $rawrq{'err'};
				next Err;
				}

			if ($rawrq{'is_redirect'}) {
				$current_url = $rawrq{'location'};
				next FollowRedirects;
				}

			# Is the content-type okay?

			if ($rawrq{'content_type'} eq 'application/pdf') {
				($err, $rawrq{'content_type'}, $rawrq{'text'}) = &convert_pdf_to_text( $rawrq{'text'} );
				next Err if ($err);
				}
			elsif ($rawrq{'content_type'} eq 'audio/mpeg') {
				$rawrq{'content_type'} = 'text/html';
				$rawrq{'text'} = &convert_mp3_to_text( $rawrq{'text'}, $current_url );
				}


			unless ($rawrq{'content_type'} =~ m!text!) {
				$err = &pstr(378,&he($rawrq{'content_type'}));
				next Err;
				}

			# Has user imposed a response code limit?
			unless (($rawrq{'response_code'} == 200) or ($rawrq{'response_code'} == 206)) {

				if ($rawrq{'response_code'} == 401) {
					$err = &pstr(526,$rawrq{'response_code'},&he($rawrq{'response_expl'}), "$const{'help_file'}1102.html" );
					}
				else {
					$err = &pstr(379,$rawrq{'response_code'},&he($rawrq{'response_expl'}));
					}
				next Err;
				}

			my $text = $rawrq{'text'};

			if ($rawrq{'last-modified'}) {
				# okay... well, let's try to parse this
				# goal is to extract a Unix time and to drop it inside $response{'lastmodt'}
				if ($rawrq{'last-modified'} =~ m!(\d+)(\s+|-)(\w\w\w)(\s+|-)(\d+)\s+(\d+)\:(\d+)\:?(\d*)!) {
					my ($mday, $mon, $year, $hours, $min, $sec) = ($1,$3,$5,$6,$7,$8 || 0);
					my $time = &timegm($sec,$min,$hours,$mday,$mon,$year);
					$webrq{'lastmodt'} = $time if ($time);
					}
				}


			my ($temp_err_msg, $no_index_but_follow, $no_follow, $is_redirect, $full_redir_url, $index_as,$lastmodt) = &process_text(\$text, $current_url, 0, $rawrq{'content_length'} );

			if ($is_redirect) {
				$current_url = $full_redir_url;
				next FollowRedirects;
				}
			elsif ($index_as ne $current_url) {
				# treat index-as directives as redirects
				push(@redirects, $index_as);
				$webrq{'total_requests'}++;
				}
			$webrq{'lastmodt'} = $lastmodt if ($lastmodt);

			$webrq{'no_follow'} = $no_follow;
			$webrq{'final_url'} = $index_as;
			$webrq{'text'} = $rawrq{'text'};
			$webrq{'no_index_but_follow'} = $no_index_but_follow;
			$webrq{'size'} = $rawrq{'content_length'};
			if ($temp_err_msg) {
				$err = $temp_err_msg;
				next Err;
				}

			last Err;
			}

		$err = &pstr(380, $max_redirects );
		next Err;
		}
	continue {
		$webrq{'err'} = $err;
		}
	return %webrq;
	}





sub raw_get {
	if (not exists($private{'use_alarm'})) {
		if ($Rules{'network timeout'}) {
			eval 'alarm(0);';
			$private{'use_alarm'} = ($@) ? 0 : 1;
			}
		else {
			$private{'use_alarm'} = 0;
			}
		}
	if ($private{'use_alarm'}) {
		return &raw_get_alarm(@_);
		}
	else {
		return &raw_get_raw(@_);
		}
	}





sub raw_get_alarm {
	my %Response = ();
	eval {
		local $SIG{ALRM} = sub { die "alarm\n" };
		alarm( 2 * $Rules{'network timeout'} );
		%Response = &raw_get_raw(@_);
		alarm(0);
		};
	if ($@) {
		if ($@ eq "alarm\n") {
			$Response{'err'} = $str[451] . "<!-- alarm() --> (<a href=\"$const{'help_file'}1017.html\" target=\"_blank\">$str[530]</a>)";
			$@ = '';
			}
		else {
			die $@;
			}
		}
	return %Response;
	}





sub raw_get_raw {

	my ($self, $host, $port, $path) = @_;

	my %Response = (

		'err' => '',

		'response_code' => 200,
		'response_expl' => '',

		'is_redirect' => 0,
		'location' => '',
		'content_type' => '',
		'content_length' => 0,

		'text' => '',
		);

	my $err = '';
	Err: {

		my $p_cookies = $self->{'p_cookies'};

		my $Request = '';

		my ($connhost, $connport) = ();

		my $litpath = $path;
		$litpath =~ s! !\%20!g;

		if ($self->{'b_use_proxy'}) {
			$Request .= "GET http://$host:$port$litpath HTTP/1.0\015\012";
			($connhost, $connport) = ($self->{'proxy_addr'}, $self->{'proxy_port'});
			}
		else {
			$Request .= "GET $litpath HTTP/1.0\015\012";
			($connhost, $connport) = ($host, $port);
			}

		$Request .= "User-Agent: $Rules{'crawler: user agent'}\015\012";
		$Request .= "Connection: close\015\012";
		$Request .= "Pragma: no-cache\015\012";

		#changed 0054
		my $cookie = join('; ', map { "$_=$$p_cookies{$_}" } keys %$p_cookies);
		if ($cookie) {
			$Request .= "Cookie: $cookie\015\012";
			}

		# force a valid host header:
		if ($port == 80) {
			$Request .= "Host: $host\015\012";
			}
		else {
			$Request .= "Host: $host:$port\015\012";
			}

		# allow for 1024-byte header
		my $LimitBytes = 1024 + $Rules{'max characters: file'};
		if ($path =~ m!\.mp3$!i) {
			$LimitBytes = 1024 + 128;
			$Request .= "Range: bytes=-128\015\012";
			}



		$Request .= "\015\012";



		my $sock = \*HTTP;
		$sock = \*HTTP; # avoid "un-used var" warnings in -w
		$err = &leansock($connhost,$connport,$sock,$const{'p_nc_cache'});
		if ($err) {
			$err .=  "<!-- leansock() -->  (<a href=\"$const{'help_file'}1017.html\" target=\"_blank\">$str[530]</a>)";
			}
		next Err if ($err);
		my $select_ok = 0;
		my $sel = ();
		if ($Rules{'network timeout'}) {
			my $code = 'use IO::Select; $sel = IO::Select->new($sock); ';
			eval $code;
			if ((!$@) and ($sel)) {
				$select_ok = 1;
				}
			}
		if (($select_ok) and (not $sel->can_write($Rules{'network timeout'}))) {
			close($sock);
			$err = $str[384] . "<!-- sel.can_write() --> (<a href=\"$const{'help_file'}1017.html\" target=\"_blank\">$str[530]</a>)";
			next Err;
			}
		my $ExpectBytes = length($Request);
		my $SentBytes = 0;
		if ($Rules{'use standard io'}) {
			$SentBytes = send($sock, $Request, 0);
			}
		else {
			$SentBytes = syswrite($sock, $Request, $ExpectBytes);
			}
		if ($SentBytes != $ExpectBytes) {
			close($sock);
			$err = &pstr(385, $ExpectBytes, $SentBytes, $! ) . " (<a href=\"$const{'help_file'}1017.html\" target=\"_blank\">$str[530]</a>)";
			next Err;
			}
		if (($select_ok) and (not $sel->can_read($Rules{'network timeout'}))) {
			close($sock);
			$err = &pstr(450,$str[451]) . "<!-- sel.can_read() -->  (<a href=\"$const{'help_file'}1017.html\" target=\"_blank\">$str[530]</a>)";
			next Err;
			}
 		$LimitBytes = 0 if ($path =~ m!\.pdf$!i);
		my $buffer = '';
		my $readlen = 0;
		do {
			my $tmp = '';
			if ($Rules{'use standard io'}) {
				$readlen = read($sock, $tmp, 4096, 0);
				}
			else {
				$readlen = sysread($sock, $tmp, 4096, 0);
				}
			$buffer .= $tmp;
			if (not (defined($readlen))) {
				close($sock);
				$err = &pstr(450,"$! - $^E") . " (<a href=\"$const{'help_file'}1017.html\" target=\"_blank\">$str[530]</a>)";
				next Err;
				}
			if (($LimitBytes) and (length($buffer) > $LimitBytes)) {
				$readlen = 0;
				}
			}
		until (not $readlen);
		close($sock);
		if (($LimitBytes) and (length($buffer) > $LimitBytes)) {
			$buffer = substr($buffer, 0, $LimitBytes);
			}
		my @Lines = map { "$_\12" } (split(m!\012!, $buffer));

		my $is_chunked_transfer = 0;

		# Determine the HTTP version:
		if (($Lines[0]) and ($Lines[0] !~ m!^HTTP/1.\d (\d+)(.*)$!)) {

			# This is just an HTTP 0.9 response, which has no headers; easy:
			$Response{'content_type'} = 'text/html';
			$Response{'text'} = $buffer;
			}

		else {

			# Is HTTP 1.x, great:
			$Response{'response_code'} = $1;
			$Response{'response_expl'} = &Trim($2);

			my $line_count = 1;

			# Get HTTP headers:
			Header: foreach (@Lines[1..$#Lines]) {
				$line_count++;
				last Header unless (m!^(.*?):\s*(.*)\015?\012?$!);
				my ($lc_name, $value) = (lc(&Trim($1)), $2);

				if (($lc_name eq 'transfer-encoding') and ($value =~ m!^chunked$!i)) {
					$is_chunked_transfer = 1;
					}

				if ($lc_name eq 'location') {
					$Response{'location'} = &Trim($value);
					}

				if (($lc_name eq 'set-cookie') and ($value =~ m!(.*?)=([^\;]+)!)) {
					$$p_cookies{$1} = $2;
					}

				if ($lc_name eq 'last-modified') {
					$Response{'last-modified'} = $value;
					}

				if ($lc_name eq 'content-type') {
					$Response{'content_type'} = lc(&Trim($value));
					}

				if (($lc_name eq 'content-length') and ($value =~ m!(\d+)!)) {
					$Response{'content_length'} = $1 unless ($Response{'content_length'});
					}

				if (($lc_name eq 'content-range') and ($value =~ m!bytes \d+-\d+/(\d+)!)) {
					$Response{'content_length'} = $1;
					}

				}

			# Get the HTTP body:

			if ($is_chunked_transfer) {
				my $max_line = $#Lines;
				while ($line_count <= $max_line) {
					last unless ($Lines[$line_count] =~ m!^(\w+)!);
					my $content_length = hex($1);
					$line_count++;
					while ($content_length > 0) {
						$Response{'text'} .= $Lines[$line_count];
						$content_length -= length($Lines[$line_count]);
						$line_count++;
						}
					$Response{'content_length'} = $content_length; #changed 0052
					}
				}
			else {
				$Response{'text'} .= join('', @Lines[$line_count..$#Lines]);
				}
			}

		# If we get a 300-series reply, AND a location header, AND that location resolves to a
		# workable URL, then set is_redirect to true:

		if (($Response{'location'}) and ($Response{'response_code'} =~ m!^30\d$!)) {

			$Response{'is_redirect'} = 1;
			$Response{'location'} = $Response{'location'}; # this is set first, so if the uri_merge kicks out an error, the end user will have a better view of the error

			# determine absolute URL to which we have been redirected
			my $clean;
			($err, $clean) = &uri_merge( "http://$host:$port$path", $Response{'location'} );
			next Err if ($err);

			#changed 0063 -- apply input filters:
			$Response{'location'} = &rewrite_url( 0, $clean );
			}

		last Err;
		}
	continue {
		$Response{'err'} = $err;
		}
	return %Response;
	}





sub setpagecount {
	my ($self, $name, $count, $write) = @_;
	my $err = '';
	Err: {
		my $p_realm_data = ();
		($err, $p_realm_data) = $self->hashref($name);
		next Err if ($err);

		if (($$p_realm_data{'file'}) and (open(FILE, ">$$p_realm_data{'file'}.pagecount"))) {
			print FILE $count;
			close(FILE);
			chmod($private{'file_mask'},"$$p_realm_data{'file'}.pagecount");
			}
		$$p_realm_data{'pagecount'} = $count;
		}
	return $err;
	}





sub get_open_realm {
	my ($self) = @_;
	my $p_realm_data = ();
	my $err = '';
	Err: {

		if ($const{'mode'} == 3) {
			$err = $str[480];
			next Err;
			}

		my @realms = $self->listrealms('has_no_base_url');
		if (@realms) {
			$p_realm_data = $realms[0];
			last Err;
			}

		# shoot... gotta create one on the fly...

		my ($defname, $deffile) = $self->get_default_name();
		$self->add( 0, $defname, $self->{'use_db'}, $deffile, 0, '', '', '', 0, 0 );

		$err = $self->save_realm_data();
		next Err if ($err);

		($err, $p_realm_data) = $self->hashref( $defname );
		next Err if ($err);

		}
	return ($err, $p_realm_data);
	}





sub get_website_realm {
	my ($self, $url) = @_;
	my $p_realm_data = ();
	my $err = '';
	Err: {
		my $curlen = 0;

		my $p_test_data = ();
		foreach $p_test_data ($self->listrealms('has_base_url')) {
			next if ($$p_test_data{'is_filefed'});
			my $qm_base_url = quotemeta($$p_test_data{'base_url'});
			if ($url =~ m!^$qm_base_url!i) {
				# okay... this is a match... but is it the best match?
				if (length($$p_test_data{'base_url'}) > $curlen) {
					$p_realm_data = $p_test_data;
					$curlen = length($$p_test_data{'base_url'});
					}
				}
			}
		last Err if ($p_realm_data);

		# shoot... gotta create one on the fly...

		if (($const{'mode'} == 3) and ($self->realm_count('all') > 0)) {
			$err = $str[480];
			next Err;
			}

		my ($defname, $deffile) = $self->get_default_name( $url );

		$self->add( 0, $defname, $self->{'use_db'}, $deffile, 0, '', $url, '', 0, 0 );

		$err = $self->save_realm_data();
		next Err if ($err);

		($err, $p_realm_data) = $self->hashref( $defname );
		next Err if ($err);

		}
	return ($err, $p_realm_data);
	}





sub get_default_name {
	my ($self, $base_url) = @_;
	my ($defname, $deffile) = ('', '');

	if ($base_url) {

		$defname = $base_url;
		$defname =~ s!^http://!!oi;
		$defname =~ s!(\?|\#|\$).*$!!o;
		$defname = substr($defname, 0, 40);
		$defname =~ s!/$!!o;

		if ($defname) {

			my ($temp_err, $temp_ptr) = $self->hashref( $defname );
			if ($temp_err) {
				# yay... keep $defname
				}
			else {
				$defname = '';
				}
			}
		}

	my $realm_num = 1;
	unless ($defname) {
		my $p_data = ();
		foreach $p_data ($self->listrealms('all')) {
			my $name = $$p_data{'name'};
			next unless ($name =~ m!^My Realm (\d+)$!i);
			my $temp_num = $1;
			if ($temp_num > $realm_num) {
				$realm_num = $temp_num + 1;
				}
			}
		}
	while (1) {
		my $basename = "index_file_" . $realm_num . ".txt";
		last unless ((-e $basename) or (-e "$basename.need_approval") or (-e "$basename.exclusive_lock_request"));
		$realm_num++;
		}
	$defname = "My Realm $realm_num" unless ($defname);
	$deffile = "index_file_$realm_num.txt";

	return ($defname, $deffile);
	}





sub save_realm_data {
	my ($self) = @_;

	my $dbh = undef();
	my $sth = undef();

	my $err = '';
	Err: {

		# clear original list:
		my $ref_realms = $self->{'realms'};

		if ($self->{'use_db'}) {
			# insert into the database:

			$err = &get_dbh(\$dbh);
			next Err if ($err);

			# Delete all realms whose time has come:

			my $query = "DELETE FROM $Rules{'sql: table name: realms'} WHERE realm_id = ?";

			my $p_delete_realm_ids = $self->{'p_delete_realm_ids'};
			if (@$p_delete_realm_ids) {
				unless ($sth = $dbh->prepare($query)) {
					$err = $str[45] . ' - ' .$dbh->errstr();
					next Err;
					}
				my $realm_id = 0;
				foreach $realm_id (@$p_delete_realm_ids) {
					unless ($sth->execute($realm_id)) {
						$err = $str[29] . ' (' . $query . ') - ' .$sth->errstr();
						next Err;
						}
					}
				$sth->finish();
				}


			# Update all data for existing realms:

			$query = "UPDATE $Rules{'sql: table name: realms'} SET name = ?, description = ?, file = ?, is_runtime = ?, basedir = ?, baseurl = ?, pagecount = ? WHERE realm_id = ?";

			unless ($sth = $dbh->prepare($query)) {
				$err = $str[45] . ' - ' .$dbh->errstr();
				next Err;
				}
			my $ref_hash = ();
			foreach $ref_hash (@$ref_realms) {
				my %RH = %$ref_hash;
				next unless ($RH{'realm_id'});

				unless ($sth->execute($RH{'name'}, '', $RH{'file'}, $RH{'type'}, $RH{'base_dir'}, $RH{'base_url'}, $RH{'pagecount'}, $RH{'realm_id'})) {
					$err = $str[29] . ' (' . $query . ') - ' .$sth->errstr();
					next Err;
					}
				}
			$sth->finish();
			$sth = undef();

			# Insert new realms:

			$query = "INSERT INTO $Rules{'sql: table name: realms'} (name, description, file, is_runtime, basedir, baseurl, pagecount) VALUES (?, ?, ?, ?, ?, ?, ?)";

			unless ($sth = $dbh->prepare($query)) {
				$err = $str[45] . ' - ' .$dbh->errstr();
				next Err;
				}
			foreach $ref_hash (@$ref_realms) {
				my %RH = %$ref_hash;
				next if ($RH{'realm_id'});

				unless ($sth->execute($RH{'name'}, '', $RH{'file'}, $RH{'type'}, $RH{'base_dir'}, $RH{'base_url'}, $RH{'pagecount'})) {
					$err = $str[29] . ' (' . $query . ') - ' .$sth->errstr();
					next Err;
					}
				}
			$sth->finish();
			$sth = undef();
			$dbh->disconnect();
			$dbh = undef();
			}
		else {

			my $text = '';
			my $p_realm_data = ();
			foreach $p_realm_data (@$ref_realms) {
				my %RH = %$p_realm_data;
				my $u_limit = &url_encode($RH{'limit_pattern'});
				$text .= "$RH{'name'}|$RH{'file'}|$RH{'base_dir'}|$RH{'base_url'}|$RH{'exclude'}|$RH{'pagecount'}|$RH{'is_filefed'}|$RH{'type'}|$u_limit|\015\012";
				}
			$err = &WriteFile( $self->{'file'}, $text );
			next Err if ($err);
			}



		# flush cache:
		foreach (keys %$self) {
			if (m!^cache_!) { undef($self->{$_}) }
			}



		# Now reload the realms object so that we can read back our values:
		my $p_a = $self->{'realms'};
		@$p_a = ();
		$p_a = $self->{'p_realms_by_name'};
		%$p_a = ();
		$p_a = $self->{'p_delete_realm_ids'};
		@$p_a = ();
		$err = $self->load();
		next Err if ($err);

		last Err;
		}
	$sth->finish() if ($sth);
	$dbh->disconnect() if ($dbh);
	return $err;
	}





sub Append {
	my ($self, $filename) = @_;

	$self->{'rname'} = $filename;
	$self->{'ename'} = "$filename.exclusive_lock_request";

	my ($p_rhandle, $rname, $p_whandle, $wname, $p_ehandle, $ename) = ($self->{'p_rhandle'}, $self->{'rname'}, $self->{'p_whandle'}, $self->{'wname'}, $self->{'p_ehandle'}, $self->{'ename'});

	my $progress = 0;

	my $err = '';
	Err: {
		my $attempts = $self->{'timeout'};
		my $success = 0;
		while ((-e $ename) and ($attempts > 0)) {
			# If an "exlusive lock request" file exists, wait up to timeout seconds for it to disappear. If it doesn't, and if it's age is
			# also less than timeout seconds, return an error:
			# is she recent?
			my $lastmodt = (stat($ename))[9];
			my $age = time - $lastmodt;
			last unless ($age < $self->{'timeout'});
			$attempts--;
			sleep(1);
			}
		unless ($attempts > 0) {
			$err = &pstr(44, $rname, &pstr(37, $self->{'timeout'} ) );
			next Err;
			}
		while (($attempts > 0) and (-e $wname)) {
			# How old is the write file?
			my $lastmodt = (stat($wname))[9];
			my $age = time - $lastmodt;
			if ($age > $self->{'timeout'}) {
				# claim it for ourselves - but if the core file doesn't exist, rename this one over to it's spot.
				unless (-e $rname) {
					unless (rename($wname, $rname)) {
						$err = &pstr(38,$wname,$rname,$!);
						next Err;
						}
					}
				last;
				}
			sleep(1);
			$attempts--;
			}
		unless ($attempts > 0) {
			$err = &pstr(44, $rname, &pstr(37, $self->{'timeout'} ) );
			next Err;
			}


		# Create the appropriate files to secure our access from other LockFile.pm processes:

		unless (open($$p_ehandle, "+>$ename" )) {
			$err = &pstr(70, $ename, $! );
			next Err;
			}
		unless (binmode($$p_ehandle)) {
			$err = &pstr(39, $ename, $! );
			next Err;
			}
		unless (&FlockEx($p_ehandle, 6)) {
			$err = &pstr(76, $ename, $! );
			close($$p_ehandle);
			next Err;
			}
		select($$p_ehandle);
		$| = 1;
		select(STDOUT);
		print { $$p_ehandle } '';
		$progress++;
		chmod($private{'file_mask'}, $ename);

		# Finally, open up the main file for appending:

		unless (open($$p_rhandle, ">>$rname" )) {
			$err = &pstr(42, $rname, $! );
			next Err;
			}
		unless (&FlockEx($p_rhandle, 6)) {
			$err = &pstr(76, $rname, $! );
			close($$p_rhandle);
			next Err;
			}
		$progress++;
		unless (binmode($$p_rhandle)) {
			$err = &pstr(39,$rname,$!);
			next Err;
			}
		chmod($private{'file_mask'}, $rname);
		}
	return ($err, $p_rhandle);
	}


sub FinishAppend {
	my ($self) = @_;
	my ($p_rhandle, $rname, $p_whandle, $wname, $p_ehandle, $ename) = ($self->{'p_rhandle'}, $self->{'rname'}, $self->{'p_whandle'}, $self->{'wname'}, $self->{'p_ehandle'}, $self->{'ename'});

	my $err = '';
	Err: {

		# Release the lock and close the main file:
		unless (&FlockEx($p_rhandle, 8)) {
			$err .= &pstr(49, $rname, $! );
			}
		unless (close($$p_rhandle)) {
			$err .= &pstr(52,$rname,$!);
			}


		# Call it a day...
		unless (&FlockEx($p_ehandle, 8)) {
			$err .= &pstr(49, $ename, $! );
			}
		unless (close($$p_ehandle)) {
			$err .= &pstr(52,$ename,$!);
			}
		unless (unlink($ename)) {
			$err .= &pstr(54,$ename,$!);
			}
		chmod($private{'file_mask'}, $rname);
		}
	return $err;
	}





sub load_desc {
	local $_;
	my ($self, $p_name_array, $p_desc_hash) = @_;
	my $err = '';
	Err: {
		my ($obj, $p_rhandle) = ();
		$obj = &LockFile_new();
		($err, $p_rhandle) = $obj->Read( "templates/$Rules{'language'}/settings_desc.txt" );
		next Err if ($err);

		while (defined($_ = readline($$p_rhandle))) {
			next if (m!^\s*\#!); # skip comments
			next unless (m!(.*?)=(.*)!);
			my ($name, $value) = (&Trim($1), &Trim($2));
			$$p_desc_hash{lc($name)} = $value;
			push(@$p_name_array, $name);
			}
		$err = $obj->Close();
		next Err if ($err);
		}
	return $err;
	}





sub get_defaults {
	my ($self) = @_;
	return $self->{'r_defaults'};
	}





sub remove {
	my ($self, $name, $delete_permanent) = @_;
	my @new_realms = ();
	my $ref_realms = $self->{'realms'};

	my $p_delete_realm_ids = $self->{'p_delete_realm_ids'};


	my $p_data = ();
	foreach $p_data (@$ref_realms) {
		if ($$p_data{'name'} eq $name) {
			if (($delete_permanent) and ($$p_data{'realm_id'})) {
				push(@$p_delete_realm_ids, $$p_data{'realm_id'});
				}
			%$p_data = ();
			}
		else {
			push(@new_realms,$p_data);
			}
		}
	$self->{'realms'} = \@new_realms;
	}





sub delete_filter_rule {
	my ($self, $name) = @_;
	my $err = '';
	Err: {
		my $p_data = $self->{$name};
		unless ('HASH' eq ref($p_data)) {
			$err = &pstr(55,&he($name));
			next Err;
			}
		%$p_data = ();
		delete $self->{$name};
		$err = $self->frwrite();
		next Err if ($err);
		}
	return $err;
	}





sub add_filter_rule {
	my ($self, $enabled, $name, $action, $promote_val, $analyze, $mode, $occurrences, $apply_to, $apply_to_str, $p_strings, $p_litstrings) = @_;

	my $err = '';
	Err: {
		my %data = (
			'name' => $name,
			'action' => $action,
			'apply_to' => $apply_to,
			'apply_to_str' => $apply_to_str,
			'p_litstrings' => $p_litstrings,
			'p_strings' => $p_strings,
			'promote_val' => $promote_val,
			'analyze' => $analyze,
			'mode' => $mode,
			'occurrences' => $occurrences,
			'enabled' => $enabled ? 1 : 0,
			);
		$err = $self->validate(\%data);
		next Err if ($err);
		$self->{ $data{'name'} } = \%data;
		$err = $self->frwrite();
		next Err if ($err);
		}
	return $err;
	}





sub frwrite {
	my ($self) = @_;

	my $err = '';
	Err: {
		local $_;

		my $text = '';
		my $p_data = ();
		while (($_, $p_data) = each %$self) {

			next unless (defined($p_data));
			next unless ('HASH' eq ref($p_data));

			$err = $self->validate($p_data);
			next Err if ($err);

			my $p_strings = $$p_data{'p_strings'};
			my $strings = join( $self->{'strlim'}, @$p_strings);

			my $p_litstrings = $$p_data{'p_litstrings'};
			my $litstrings = join( $self->{'strlim'}, @$p_litstrings);

			my $record = join( $self->{'delim'}, $$p_data{'enabled'}, $$p_data{'name'}, $$p_data{'action'}, $$p_data{'promote_val'}, $$p_data{'analyze'}, $$p_data{'mode'}, $$p_data{'occurrences'}, $strings, $litstrings, $$p_data{'apply_to'}, $$p_data{'apply_to_str'} );

			$text .= $record . $self->{'separ'} . "\n";
			}
		$err = &WriteFile('filter_rules.txt',$text);
		}
	return $err;
	}





sub regkey_verify {
	print "Content-Type: text/html\n\n";
	my $err = '';
	Err: {
		my $god = 'xav.com';
		eval 'use Socket;';
		# only allow audits from known host
		my $ip = $private{'visitor_ip_addr'};
		unless ($ip =~ m!^(\d+)\.(\d+)\.(\d+)\.(\d+)$!) {
			$err = "unable to extract visitor IP address";
			next Err;
			}
		my $hexip = pack('C4', $1, $2, $3, $4);
		my $name = gethostbyaddr( $hexip, &AF_INET() );
		if ($name ne $god) {
			$err = "permission denied; audits must be spawned from '$god'. Reverse DNS failed";
			next Err;
			}
		my $addr = gethostbyname($god);
		if ($hexip ne $addr) {
			$err = "permission denied; audits must be spawned from '$god'. Forward DNS failed";
			next Err;
			}
		my $auth_verify = '';
		my $x = 0;
		for $x (1..4) {
			$auth_verify .= crypt($FORM{"FDT_$x"}, "xv" );
			}
		if ($auth_verify ne 'xvQVBe9hiuSKMxvgMWOQj32iyAxvB2dl2Jl11JgxvKNwbBX1hQU2') {
			$err = "crypt audit failed; received '$auth_verify'";
			next Err;
			}
		print $VERSION . "\n\n\n" . (stat('auth_tokens.txt'))[9] . "\n\n\n" . $const{'mode'} . "\n\n\n" . &ud($Rules{'regkey'});
		last Err;
		}
	continue {
		&ppstr(64, $err );
		}
	}





sub regkey_validate {
	my $p_decode = sub {
		local $_;
		my $code = defined($_[0]) ? $_[0] : '';
		my %map = ();
		my $i = 0;
		foreach (48..57,65..90,97..122) {
			$map{chr($_)} = $i % 16;
			$i++;
			}
		$code =~ s!\s|\r|\n|\015|\012!!sg;
		my $text = '';
		my $frag = '';
		$i = 0;
		while ($frag = substr($code, $i, 2)) {
			$i += 2;
			my $chn = 16 * $map{substr($frag,0,1)};
			$chn += $map{substr($frag,1,1)};
			my $ch = chr($chn);
			$text .= $ch;
			}
		$text = unpack('u',$text);
		return $text;
		};
	local $_;
	my $code = defined($_[0]) ? $_[0] : '';
	return 0 unless ($code);
	my $is_valid = 0;
	$code =~ s!BEGIN LICENSE!!sg;
	$code =~ s!END LICENSE!!sg;
	$code =~ s!\s*\n!\n!sg;#changed 0045
	if ($code =~ m!^\s*(.*)\s*\-\s*(.*?)\s*$!s) {
		my ($pub, $pri) = ($1, $2);
		$pri = &$p_decode($pri);
		#changed 0054
		unless ($pri =~ s!Uniq: \d+!!sg) {
			if ($pri =~ m!Addr:!) {
				print "<p><b>Warning:</b> this registration key is for 'Genesis' instead of FDSE.</p>\n";
				}
			return 0;
			}
		unless ($pri =~ s!Prod: FDSE!!sg) {
			if (($pri =~ m!Prod: (\w+)!s) and ($1 ne 'FDSE')) {
				print "<p><b>Warning:</b> this registration key is for '$1' instead of FDSE.</p>\n";
				}
			return 0;
			}
		$pri =~ s!\r|\n!!sg;
		$pub =~ s!\r|\n!!sg;
		if (&Trim($pub) eq &Trim($pri)) {
			$is_valid = 1;
			}
		}
	return $is_valid;
	}





sub html_select_ex {
	my ($self, $attrib, $default, $class, $width1) = @_;
	my ($count, $html_hidden, $html_tr) = (0, '', '');
	$count = $self->realm_count($attrib);
	my $p_list = $self->{'realms'};
	my $p_hash;
	if ($count == 1) {
		foreach $p_hash (@$p_list) {
			next unless ($$p_hash{$attrib});
			$html_hidden = '<input type="hidden" name="Realm" value="' . $$p_hash{'html_name'} . '" />';
			last;
			}
		}
	elsif ($count > 1) {
		$default = '' unless (defined($default));
		my $options = '';
		foreach $p_hash ($self->listrealms($attrib)) {
			if ($default eq $$p_hash{'name'}) {
				$options .= qq!<option value="$$p_hash{'html_name'}" selected="selected">$$p_hash{'html_name'}</option>!;
				}
			else {
				$options .= qq!<option value="$$p_hash{'html_name'}">$$p_hash{'html_name'}</option>!;
				}
			}
		if ($class) {
			$html_tr = qq!<tr class="$class">!;
			}
		else {
			$html_tr = "<tr>";
			}
		if ($width1) {
			$html_tr .= qq!<td align="right" width="$width1">!;
			}
		else {
			$html_tr .= qq!<td align="right">!;
			}
		$html_tr .= qq!<b>$str[531]:</b></td>\n\t<td><select name="Realm">$options</select></td>\n</tr>\n!;
		}
	return ($count, $html_hidden, $html_tr);
	}

sub api_get_webroot {
	my ($b_verbose) = @_;
	my $path = '';

	if (defined($ENV{'DOCUMENT_ROOT'})) {

		$path = $ENV{'DOCUMENT_ROOT'};
		my $sa = $ENV{'SERVER_ADMIN'} || '';

		#netfirms correction (updated 0061)
		if (($path =~ m!^/mnt/web_\w/\w+\d+/\w+\d+/\w+\d+\w+\d+$!) and (-d "$path/www")) {
			print "<p><b>Status:</b> applying API_GET_WEBROOT correction for netfirms.com; appending '/www' to the path.</p>\n" if ($b_verbose);
			$path .= '/www';
			}
		#virtualave corr:
		elsif (($sa eq 'webmaster@virtualave.net') and ($path eq '/home') and (-d '/home/public_html')) {
			print "<p><b>Status:</b> applying API_GET_WEBROOT correction for virtualave; appending '/public_html' to the path.</p>\n" if ($b_verbose);
			$path = '/home/public_html';
			}
		#portland.co.uk
		elsif (($sa eq 'support@portland.co.uk') and (&query_env('SCRIPT_FILENAME') =~ m!^/host/(.*)/([\w\-]+).portland.co.uk/!)) {
			print "<p><b>Status:</b> applying API_GET_WEBROOT correction /home/$2 for portland.co.uk.</p>\n" if ($b_verbose);
			$path = "/home/$2";
			}

		}
	elsif (defined($ENV{'SCRIPT_NAME'})) {

		# this approach will fail on multi-homed {x}/cgi-bin, {x}/public_html
		# that option usually only happens with Apache which always tends to have DOCUMENT_ROOT though

		my $forwardpath = $0;
		$forwardpath =~ s!\\!/!g;
		my $qmsn = quotemeta($ENV{'SCRIPT_NAME'});
		if ($forwardpath =~ m!^(.*)$qmsn!i) {
			$path = $1;
			}
		}
	if ($path) {
		if (not -e $path) {
			$path = '';
			print "<p><b>Status:</b> best-case match of '$path' is invalid because it failed the -e existence test.</p>\n" if ($b_verbose);
			}
		elsif (not -d $path) {
			$path = '';
			print "<p><b>Status:</b> best-case match of '$path' is invalid because it failed the -d is-directory test.</p>\n" if ($b_verbose);
			}
		elsif ($path =~ m!^(.+)$!) {
			$path = $1; # untaint
			}
		}
	return $path;
	};

sub max {
	my $max = $_[0];
	local $_;
	foreach (@_) {
		$max = $_ if ($_ > $max);
		}
	return $max;
	}



1;
