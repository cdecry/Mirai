# This file is auto-generated by the Perl DateTime Suite time zone
# code generator (0.07) This code generator comes with the
# DateTime::TimeZone module distribution in the tools/ directory

#
# Generated from /tmp/G45iu_6zbF/asia.  Olson data version 2013h
#
# Do not edit this file directly.
#
package DateTime::TimeZone::Asia::Macau;
{
  $DateTime::TimeZone::Asia::Macau::VERSION = '1.63';
}
BEGIN {
  $DateTime::TimeZone::Asia::Macau::AUTHORITY = 'cpan:DROLSKY';
}

use strict;

use Class::Singleton 1.03;
use DateTime::TimeZone;
use DateTime::TimeZone::OlsonDB;

@DateTime::TimeZone::Asia::Macau::ISA = ( 'Class::Singleton', 'DateTime::TimeZone' );

my $spans =
[
    [
DateTime::TimeZone::NEG_INFINITY, #    utc_start
60305271940, #      utc_end 1911-12-31 16:25:40 (Sun)
DateTime::TimeZone::NEG_INFINITY, #  local_start
60305299200, #    local_end 1912-01-01 00:00:00 (Mon)
27260,
0,
'LMT',
    ],
    [
60305271940, #    utc_start 1911-12-31 16:25:40 (Sun)
61858323000, #      utc_end 1961-03-18 19:30:00 (Sat)
60305300740, #  local_start 1912-01-01 00:25:40 (Mon)
61858351800, #    local_end 1961-03-19 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
61858323000, #    utc_start 1961-03-18 19:30:00 (Sat)
61878277800, #      utc_end 1961-11-04 18:30:00 (Sat)
61858355400, #  local_start 1961-03-19 04:30:00 (Sun)
61878310200, #    local_end 1961-11-05 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
61878277800, #    utc_start 1961-11-04 18:30:00 (Sat)
61889772600, #      utc_end 1962-03-17 19:30:00 (Sat)
61878306600, #  local_start 1961-11-05 02:30:00 (Sun)
61889801400, #    local_end 1962-03-18 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
61889772600, #    utc_start 1962-03-17 19:30:00 (Sat)
61909727400, #      utc_end 1962-11-03 18:30:00 (Sat)
61889805000, #  local_start 1962-03-18 04:30:00 (Sun)
61909759800, #    local_end 1962-11-04 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
61909727400, #    utc_start 1962-11-03 18:30:00 (Sat)
61921209600, #      utc_end 1963-03-16 16:00:00 (Sat)
61909756200, #  local_start 1962-11-04 02:30:00 (Sun)
61921238400, #    local_end 1963-03-17 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
61921209600, #    utc_start 1963-03-16 16:00:00 (Sat)
61941177000, #      utc_end 1963-11-02 18:30:00 (Sat)
61921242000, #  local_start 1963-03-17 01:00:00 (Sun)
61941209400, #    local_end 1963-11-03 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
61941177000, #    utc_start 1963-11-02 18:30:00 (Sat)
61953276600, #      utc_end 1964-03-21 19:30:00 (Sat)
61941205800, #  local_start 1963-11-03 02:30:00 (Sun)
61953305400, #    local_end 1964-03-22 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
61953276600, #    utc_start 1964-03-21 19:30:00 (Sat)
61972626600, #      utc_end 1964-10-31 18:30:00 (Sat)
61953309000, #  local_start 1964-03-22 04:30:00 (Sun)
61972659000, #    local_end 1964-11-01 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
61972626600, #    utc_start 1964-10-31 18:30:00 (Sat)
61984713600, #      utc_end 1965-03-20 16:00:00 (Sat)
61972655400, #  local_start 1964-11-01 02:30:00 (Sun)
61984742400, #    local_end 1965-03-21 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
61984713600, #    utc_start 1965-03-20 16:00:00 (Sat)
62004063600, #      utc_end 1965-10-30 15:00:00 (Sat)
61984746000, #  local_start 1965-03-21 01:00:00 (Sun)
62004096000, #    local_end 1965-10-31 00:00:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62004063600, #    utc_start 1965-10-30 15:00:00 (Sat)
62018595000, #      utc_end 1966-04-16 19:30:00 (Sat)
62004092400, #  local_start 1965-10-30 23:00:00 (Sat)
62018623800, #    local_end 1966-04-17 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62018595000, #    utc_start 1966-04-16 19:30:00 (Sat)
62034316200, #      utc_end 1966-10-15 18:30:00 (Sat)
62018627400, #  local_start 1966-04-17 04:30:00 (Sun)
62034348600, #    local_end 1966-10-16 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62034316200, #    utc_start 1966-10-15 18:30:00 (Sat)
62050044600, #      utc_end 1967-04-15 19:30:00 (Sat)
62034345000, #  local_start 1966-10-16 02:30:00 (Sun)
62050073400, #    local_end 1967-04-16 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62050044600, #    utc_start 1967-04-15 19:30:00 (Sat)
62066370600, #      utc_end 1967-10-21 18:30:00 (Sat)
62050077000, #  local_start 1967-04-16 04:30:00 (Sun)
62066403000, #    local_end 1967-10-22 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62066370600, #    utc_start 1967-10-21 18:30:00 (Sat)
62082099000, #      utc_end 1968-04-20 19:30:00 (Sat)
62066399400, #  local_start 1967-10-22 02:30:00 (Sun)
62082127800, #    local_end 1968-04-21 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62082099000, #    utc_start 1968-04-20 19:30:00 (Sat)
62097820200, #      utc_end 1968-10-19 18:30:00 (Sat)
62082131400, #  local_start 1968-04-21 04:30:00 (Sun)
62097852600, #    local_end 1968-10-20 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62097820200, #    utc_start 1968-10-19 18:30:00 (Sat)
62113548600, #      utc_end 1969-04-19 19:30:00 (Sat)
62097849000, #  local_start 1968-10-20 02:30:00 (Sun)
62113577400, #    local_end 1969-04-20 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62113548600, #    utc_start 1969-04-19 19:30:00 (Sat)
62129269800, #      utc_end 1969-10-18 18:30:00 (Sat)
62113581000, #  local_start 1969-04-20 04:30:00 (Sun)
62129302200, #    local_end 1969-10-19 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62129269800, #    utc_start 1969-10-18 18:30:00 (Sat)
62144998200, #      utc_end 1970-04-18 19:30:00 (Sat)
62129298600, #  local_start 1969-10-19 02:30:00 (Sun)
62145027000, #    local_end 1970-04-19 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62144998200, #    utc_start 1970-04-18 19:30:00 (Sat)
62160719400, #      utc_end 1970-10-17 18:30:00 (Sat)
62145030600, #  local_start 1970-04-19 04:30:00 (Sun)
62160751800, #    local_end 1970-10-18 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62160719400, #    utc_start 1970-10-17 18:30:00 (Sat)
62176447800, #      utc_end 1971-04-17 19:30:00 (Sat)
62160748200, #  local_start 1970-10-18 02:30:00 (Sun)
62176476600, #    local_end 1971-04-18 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62176447800, #    utc_start 1971-04-17 19:30:00 (Sat)
62192169000, #      utc_end 1971-10-16 18:30:00 (Sat)
62176480200, #  local_start 1971-04-18 04:30:00 (Sun)
62192201400, #    local_end 1971-10-17 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62192169000, #    utc_start 1971-10-16 18:30:00 (Sat)
62207884800, #      utc_end 1972-04-15 16:00:00 (Sat)
62192197800, #  local_start 1971-10-17 02:30:00 (Sun)
62207913600, #    local_end 1972-04-16 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62207884800, #    utc_start 1972-04-15 16:00:00 (Sat)
62223606000, #      utc_end 1972-10-14 15:00:00 (Sat)
62207917200, #  local_start 1972-04-16 01:00:00 (Sun)
62223638400, #    local_end 1972-10-15 00:00:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62223606000, #    utc_start 1972-10-14 15:00:00 (Sat)
62239334400, #      utc_end 1973-04-14 16:00:00 (Sat)
62223634800, #  local_start 1972-10-14 23:00:00 (Sat)
62239363200, #    local_end 1973-04-15 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62239334400, #    utc_start 1973-04-14 16:00:00 (Sat)
62255660400, #      utc_end 1973-10-20 15:00:00 (Sat)
62239366800, #  local_start 1973-04-15 01:00:00 (Sun)
62255692800, #    local_end 1973-10-21 00:00:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62255660400, #    utc_start 1973-10-20 15:00:00 (Sat)
62271388800, #      utc_end 1974-04-20 16:00:00 (Sat)
62255689200, #  local_start 1973-10-20 23:00:00 (Sat)
62271417600, #    local_end 1974-04-21 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62271388800, #    utc_start 1974-04-20 16:00:00 (Sat)
62287122600, #      utc_end 1974-10-19 18:30:00 (Sat)
62271421200, #  local_start 1974-04-21 01:00:00 (Sun)
62287155000, #    local_end 1974-10-20 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62287122600, #    utc_start 1974-10-19 18:30:00 (Sat)
62302851000, #      utc_end 1975-04-19 19:30:00 (Sat)
62287151400, #  local_start 1974-10-20 02:30:00 (Sun)
62302879800, #    local_end 1975-04-20 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62302851000, #    utc_start 1975-04-19 19:30:00 (Sat)
62318572200, #      utc_end 1975-10-18 18:30:00 (Sat)
62302883400, #  local_start 1975-04-20 04:30:00 (Sun)
62318604600, #    local_end 1975-10-19 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62318572200, #    utc_start 1975-10-18 18:30:00 (Sat)
62334300600, #      utc_end 1976-04-17 19:30:00 (Sat)
62318601000, #  local_start 1975-10-19 02:30:00 (Sun)
62334329400, #    local_end 1976-04-18 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62334300600, #    utc_start 1976-04-17 19:30:00 (Sat)
62350021800, #      utc_end 1976-10-16 18:30:00 (Sat)
62334333000, #  local_start 1976-04-18 04:30:00 (Sun)
62350054200, #    local_end 1976-10-17 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62350021800, #    utc_start 1976-10-16 18:30:00 (Sat)
62365750200, #      utc_end 1977-04-16 19:30:00 (Sat)
62350050600, #  local_start 1976-10-17 02:30:00 (Sun)
62365779000, #    local_end 1977-04-17 03:30:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62365750200, #    utc_start 1977-04-16 19:30:00 (Sat)
62381471400, #      utc_end 1977-10-15 18:30:00 (Sat)
62365782600, #  local_start 1977-04-17 04:30:00 (Sun)
62381503800, #    local_end 1977-10-16 03:30:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62381471400, #    utc_start 1977-10-15 18:30:00 (Sat)
62397187200, #      utc_end 1978-04-15 16:00:00 (Sat)
62381500200, #  local_start 1977-10-16 02:30:00 (Sun)
62397216000, #    local_end 1978-04-16 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62397187200, #    utc_start 1978-04-15 16:00:00 (Sat)
62412908400, #      utc_end 1978-10-14 15:00:00 (Sat)
62397219600, #  local_start 1978-04-16 01:00:00 (Sun)
62412940800, #    local_end 1978-10-15 00:00:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62412908400, #    utc_start 1978-10-14 15:00:00 (Sat)
62428636800, #      utc_end 1979-04-14 16:00:00 (Sat)
62412937200, #  local_start 1978-10-14 23:00:00 (Sat)
62428665600, #    local_end 1979-04-15 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62428636800, #    utc_start 1979-04-14 16:00:00 (Sat)
62444962800, #      utc_end 1979-10-20 15:00:00 (Sat)
62428669200, #  local_start 1979-04-15 01:00:00 (Sun)
62444995200, #    local_end 1979-10-21 00:00:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62444962800, #    utc_start 1979-10-20 15:00:00 (Sat)
62460691200, #      utc_end 1980-04-19 16:00:00 (Sat)
62444991600, #  local_start 1979-10-20 23:00:00 (Sat)
62460720000, #    local_end 1980-04-20 00:00:00 (Sun)
28800,
0,
'MOT',
    ],
    [
62460691200, #    utc_start 1980-04-19 16:00:00 (Sat)
62476412400, #      utc_end 1980-10-18 15:00:00 (Sat)
62460723600, #  local_start 1980-04-20 01:00:00 (Sun)
62476444800, #    local_end 1980-10-19 00:00:00 (Sun)
32400,
1,
'MOST',
    ],
    [
62476412400, #    utc_start 1980-10-18 15:00:00 (Sat)
63081302400, #      utc_end 1999-12-19 16:00:00 (Sun)
62476441200, #  local_start 1980-10-18 23:00:00 (Sat)
63081331200, #    local_end 1999-12-20 00:00:00 (Mon)
28800,
0,
'MOT',
    ],
    [
63081302400, #    utc_start 1999-12-19 16:00:00 (Sun)
DateTime::TimeZone::INFINITY, #      utc_end
63081331200, #  local_start 1999-12-20 00:00:00 (Mon)
DateTime::TimeZone::INFINITY, #    local_end
28800,
0,
'CST',
    ],
];

sub olson_version { '2013h' }

sub has_dst_changes { 20 }

sub _max_year { 2023 }

sub _new_instance
{
    return shift->_init( @_, spans => $spans );
}



1;

