﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using System.Drawing;

namespace StrefaRDM
{
    class PedMenu : BaseScript
    {
        bool visible = false;
        private Dictionary<string, string> models = new Dictionary<string, string>()
        {
            ["a_m_m_afriamer_01"] = "AfriAmer01AMM",
            ["a_m_m_beach_01"] = "Beach01AMM",
            ["a_m_m_beach_02"] = "Beach02AMM",
            ["a_m_m_bevhills_01"] = "Bevhills01AMM",
            ["a_m_m_bevhills_02"] = "Bevhills02AMM",
            ["a_m_m_business_01"] = "Business01AMM",
            ["a_m_m_eastsa_01"] = "Eastsa01AMM",
            ["a_m_m_eastsa_02"] = "Eastsa02AMM",
            ["a_m_m_farmer_01"] = "Farmer01AMM",
            ["a_m_m_fatlatin_01"] = "Fatlatin01AMM",
            ["a_m_m_genfat_01"] = "Genfat01AMM",
            ["a_m_m_genfat_02"] = "Genfat02AMM",
            ["a_m_m_golfer_01"] = "Golfer01AMM",
            ["a_m_m_hasjew_01"] = "Hasjew01AMM",
            ["a_m_m_hillbilly_01"] = "Hillbilly01AMM",
            ["a_m_m_hillbilly_02"] = "Hillbilly02AMM",
            ["a_m_m_indian_01"] = "Indian01AMM",
            ["a_m_m_ktown_01"] = "Ktown01AMM",
            ["a_m_m_malibu_01"] = "Malibu01AMM",
            ["a_m_m_mexcntry_01"] = "MexCntry01AMM",
            ["a_m_m_mexlabor_01"] = "MexLabor01AMM",
            ["a_m_m_og_boss_01"] = "OgBoss01AMM",
            ["a_m_m_paparazzi_01"] = "Paparazzi01AMM",
            ["a_m_m_polynesian_01"] = "Polynesian01AMM",
            ["a_m_m_prolhost_01"] = "PrologueHostage01AMM",
            ["a_m_m_rurmeth_01"] = "Rurmeth01AMM",
            ["a_m_m_salton_01"] = "Salton01AMM",
            ["a_m_m_salton_02"] = "Salton02AMM",
            ["a_m_m_salton_03"] = "Salton03AMM",
            ["a_m_m_salton_04"] = "Salton04AMM",
            ["a_m_m_skater_01"] = "Skater01AMM",
            ["a_m_m_skidrow_01"] = "Skidrow01AMM",
            ["a_m_m_socenlat_01"] = "Socenlat01AMM",
            ["a_m_m_soucent_01"] = "Soucent01AMM",
            ["a_m_m_soucent_02"] = "Soucent02AMM",
            ["a_m_m_soucent_03"] = "Soucent03AMM",
            ["a_m_m_soucent_04"] = "Soucent04AMM",
            ["a_m_m_stlat_02"] = "Stlat02AMM",
            ["a_m_m_tennis_01"] = "Tennis01AMM",
            ["a_m_m_tourist_01"] = "Tourist01AMM",
            ["a_m_m_trampbeac_01"] = "TrampBeac01AMM",
            ["a_m_m_tramp_01"] = "Tramp01AMM",
            ["a_m_m_tranvest_01"] = "Tranvest01AMM",
            ["a_m_m_tranvest_02"] = "Tranvest02AMM",
            ["a_m_o_beach_01"] = "Beach01AMO",
            ["a_m_o_genstreet_01"] = "Genstreet01AMO",
            ["a_m_o_ktown_01"] = "Ktown01AMO",
            ["a_m_o_salton_01"] = "Salton01AMO",
            ["a_m_o_soucent_01"] = "Soucent01AMO",
            ["a_m_o_soucent_02"] = "Soucent02AMO",
            ["a_m_o_soucent_03"] = "Soucent03AMO",
            ["a_m_o_tramp_01"] = "Tramp01AMO",
            ["a_m_y_beachvesp_01"] = "Beachvesp01AMY",
            ["a_m_y_beachvesp_02"] = "Beachvesp02AMY",
            ["a_m_y_beach_01"] = "Beach01AMY",
            ["a_m_y_beach_02"] = "Beach02AMY",
            ["a_m_y_beach_03"] = "Beach03AMY",
            ["a_m_y_bevhills_01"] = "Bevhills01AMY",
            ["a_m_y_bevhills_02"] = "Bevhills02AMY",
            ["a_m_y_breakdance_01"] = "Breakdance01AMY",
            ["a_m_y_busicas_01"] = "Busicas01AMY",
            ["a_m_y_business_01"] = "Business01AMY",
            ["a_m_y_business_02"] = "Business02AMY",
            ["a_m_y_business_03"] = "Business03AMY",
            ["a_m_y_cyclist_01"] = "Cyclist01AMY",
            ["a_m_y_dhill_01"] = "Dhill01AMY",
            ["a_m_y_downtown_01"] = "Downtown01AMY",
            ["a_m_y_eastsa_01"] = "Eastsa01AMY",
            ["a_m_y_eastsa_02"] = "Eastsa02AMY",
            ["a_m_y_epsilon_01"] = "Epsilon01AMY",
            ["a_m_y_epsilon_02"] = "Epsilon02AMY",
            ["a_m_y_gay_01"] = "Gay01AMY",
            ["a_m_y_gay_02"] = "Gay02AMY",
            ["a_m_y_genstreet_01"] = "Genstreet01AMY",
            ["a_m_y_genstreet_02"] = "Genstreet02AMY",
            ["a_m_y_golfer_01"] = "Golfer01AMY",
            ["a_m_y_hasjew_01"] = "Hasjew01AMY",
            ["a_m_y_hiker_01"] = "Hiker01AMY",
            ["a_m_y_hippy_01"] = "Hippy01AMY",
            ["a_m_y_hipster_01"] = "Hipster01AMY",
            ["a_m_y_hipster_02"] = "Hipster02AMY",
            ["a_m_y_hipster_03"] = "Hipster03AMY",
            ["a_m_y_indian_01"] = "Indian01AMY",
            ["a_m_y_jetski_01"] = "Jetski01AMY",
            ["a_m_y_juggalo_01"] = "Juggalo01AMY",
            ["a_m_y_ktown_01"] = "Ktown01AMY",
            ["a_m_y_ktown_02"] = "Ktown02AMY",
            ["a_m_y_latino_01"] = "Latino01AMY",
            ["a_m_y_methhead_01"] = "Methhead01AMY",
            ["a_m_y_mexthug_01"] = "MexThug01AMY",
            ["a_m_y_motox_01"] = "Motox01AMY",
            ["a_m_y_motox_02"] = "Motox02AMY",
            ["a_m_y_musclbeac_01"] = "Musclbeac01AMY",
            ["a_m_y_musclbeac_02"] = "Musclbeac02AMY",
            ["a_m_y_polynesian_01"] = "Polynesian01AMY",
            ["a_m_y_roadcyc_01"] = "Roadcyc01AMY",
            ["a_m_y_runner_01"] = "Runner01AMY",
            ["a_m_y_runner_02"] = "Runner02AMY",
            ["a_m_y_salton_01"] = "Salton01AMY",
            ["a_m_y_skater_01"] = "Skater01AMY",
            ["a_m_y_skater_02"] = "Skater02AMY",
            ["a_m_y_soucent_01"] = "Soucent01AMY",
            ["a_m_y_soucent_02"] = "Soucent02AMY",
            ["a_m_y_soucent_03"] = "Soucent03AMY",
            ["a_m_y_soucent_04"] = "Soucent04AMY",
            ["a_m_y_stbla_01"] = "Stbla01AMY",
            ["a_m_y_stbla_02"] = "Stbla02AMY",
            ["a_m_y_stlat_01"] = "Stlat01AMY",
            ["a_m_y_stwhi_01"] = "Stwhi01AMY",
            ["a_m_y_stwhi_02"] = "Stwhi02AMY",
            ["a_m_y_sunbathe_01"] = "Sunbathe01AMY",
            ["a_m_y_surfer_01"] = "Surfer01AMY",
            ["a_m_y_vindouche_01"] = "Vindouche01AMY",
            ["a_m_y_vinewood_01"] = "Vinewood01AMY",
            ["a_m_y_vinewood_02"] = "Vinewood02AMY",
            ["a_m_y_vinewood_03"] = "Vinewood03AMY",
            ["a_m_y_vinewood_04"] = "Vinewood04AMY",
            ["a_m_y_yoga_01"] = "Yoga01AMY",
            ["a_f_m_beach_01"] = "Beach01AFM",
            ["a_f_m_bevhills_01"] = "Bevhills01AFM",
            ["a_f_m_bevhills_02"] = "Bevhills02AFM",
            ["a_f_m_bodybuild_01"] = "Bodybuild01AFM",
            ["a_f_m_business_02"] = "Business02AFM",
            ["a_f_m_downtown_01"] = "Downtown01AFM",
            ["a_f_m_eastsa_01"] = "Eastsa01AFM",
            ["a_f_m_eastsa_02"] = "Eastsa02AFM",
            ["a_f_m_fatbla_01"] = "FatBla01AFM",
            ["a_f_m_fatcult_01"] = "FatCult01AFM",
            ["a_f_m_fatwhite_01"] = "FatWhite01AFM",
            ["a_f_m_ktown_01"] = "Ktown01AFM",
            ["a_f_m_ktown_02"] = "Ktown02AFM",
            ["a_f_m_prolhost_01"] = "PrologueHostage01AFM",
            ["a_f_m_salton_01"] = "Salton01AFM",
            ["a_f_m_skidrow_01"] = "Skidrow01AFM",
            ["a_f_m_soucentmc_01"] = "Soucentmc01AFM",
            ["a_f_m_soucent_01"] = "Soucent01AFM",
            ["a_f_m_soucent_02"] = "Soucent02AFM",
            ["a_f_m_tourist_01"] = "Tourist01AFM",
            ["a_f_m_trampbeac_01"] = "TrampBeac01AFM",
            ["a_f_m_tramp_01"] = "Tramp01AFM",
            ["a_f_o_genstreet_01"] = "Genstreet01AFO",
            ["a_f_o_indian_01"] = "Indian01AFO",
            ["a_f_o_ktown_01"] = "Ktown01AFO",
            ["a_f_o_salton_01"] = "Salton01AFO",
            ["a_f_o_soucent_01"] = "Soucent01AFO",
            ["a_f_o_soucent_02"] = "Soucent02AFO",
            ["a_f_y_beach_01"] = "Beach01AFY",
            ["a_f_y_bevhills_01"] = "Bevhills01AFY",
            ["a_f_y_bevhills_02"] = "Bevhills02AFY",
            ["a_f_y_bevhills_03"] = "Bevhills03AFY",
            ["a_f_y_bevhills_04"] = "Bevhills04AFY",
            ["a_f_y_business_01"] = "Business01AFY",
            ["a_f_y_business_02"] = "Business02AFY",
            ["a_f_y_business_03"] = "Business03AFY",
            ["a_f_y_business_04"] = "Business04AFY",
            ["a_f_y_eastsa_01"] = "Eastsa01AFY",
            ["a_f_y_eastsa_02"] = "Eastsa02AFY",
            ["a_f_y_eastsa_03"] = "Eastsa03AFY",
            ["a_f_y_epsilon_01"] = "Epsilon01AFY",
            ["a_f_y_fitness_01"] = "Fitness01AFY",
            ["a_f_y_fitness_02"] = "Fitness02AFY",
            ["a_f_y_genhot_01"] = "Genhot01AFY",
            ["a_f_y_golfer_01"] = "Golfer01AFY",
            ["a_f_y_hiker_01"] = "Hiker01AFY",
            ["a_f_y_hippie_01"] = "Hippie01AFY",
            ["a_f_y_hipster_01"] = "Hipster01AFY",
            ["a_f_y_hipster_02"] = "Hipster02AFY",
            ["a_f_y_hipster_03"] = "Hipster03AFY",
            ["a_f_y_hipster_04"] = "Hipster04AFY",
            ["a_f_y_indian_01"] = "Indian01AFY",
            ["a_f_y_juggalo_01"] = "Juggalo01AFY",
            ["a_f_y_runner_01"] = "Runner01AFY",
            ["a_f_y_rurmeth_01"] = "Rurmeth01AFY",
            ["a_f_y_scdressy_01"] = "Scdressy01AFY",
            ["a_f_y_skater_01"] = "Skater01AFY",
            ["a_f_y_soucent_01"] = "Soucent01AFY",
            ["a_f_y_soucent_02"] = "Soucent02AFY",
            ["a_f_y_soucent_03"] = "Soucent03AFY",
            ["a_f_y_tennis_01"] = "Tennis01AFY",
            ["a_f_y_topless_01"] = "Topless01AFY",
            ["a_f_y_tourist_01"] = "Tourist01AFY",
            ["a_f_y_tourist_02"] = "Tourist02AFY",
            ["a_f_y_vinewood_01"] = "Vinewood01AFY",
            ["a_f_y_vinewood_02"] = "Vinewood02AFY",
            ["a_f_y_vinewood_03"] = "Vinewood03AFY",
            ["a_f_y_vinewood_04"] = "Vinewood04AFY",
            ["a_f_y_yoga_01"] = "Yoga01AFY",
            ["csb_abigail"] = "AbigailCutscene",
            ["csb_anita"] = "AnitaCutscene",
            ["csb_anton"] = "AntonCutscene",
            ["csb_ballasog"] = "BallasogCutscene",
            ["csb_burgerdrug"] = "BurgerDrugCutscene",
            ["csb_car3guy1"] = "Car3Guy1Cutscene",
            ["csb_car3guy2"] = "Car3Guy2Cutscene",
            ["csb_chef"] = "ChefCutscene",
            ["csb_chin_goon"] = "ChinGoonCutscene",
            ["csb_cletus"] = "CletusCutscene",
            ["csb_cop"] = "CopCutscene",
            ["csb_customer"] = "CustomerCutscene",
            ["csb_denise_friend"] = "DeniseFriendCutscene",
            ["csb_fos_rep"] = "FosRepCutscene",
            ["csb_grove_str_dlr"] = "GroveStrDlrCutscene",
            ["csb_g"] = "GCutscene",
            ["csb_hao"] = "HaoCutscene",
            ["csb_hugh"] = "HughCutscene",
            ["csb_imran"] = "ImranCutscene",
            ["csb_janitor"] = "JanitorCutscene",
            ["csb_maude"] = "MaudeCutscene",
            ["csb_mweather"] = "MerryWeatherCutscene",
            ["csb_ortega"] = "OrtegaCutscene",
            ["csb_oscar"] = "OscarCutscene",
            ["csb_porndudes"] = "PornDudesCutscene",
            ["csb_prologuedriver"] = "PrologueDriverCutscene",
            ["csb_prolsec"] = "PrologueSec01Cutscene",
            ["csb_ramp_gang"] = "RampGangCutscene",
            ["csb_ramp_hic"] = "RampHicCutscene",
            ["csb_ramp_hipster"] = "RampHipsterCutscene",
            ["csb_ramp_marine"] = "RampMarineCutscene",
            ["csb_ramp_mex"] = "RampMexCutscene",
            ["csb_reporter"] = "ReporterCutscene",
            ["csb_roccopelosi"] = "RoccoPelosiCutscene",
            ["csb_screen_writer"] = "ScreenWriterCutscene",
            ["csb_stripper_01"] = "Stripper01Cutscene",
            ["csb_stripper_02"] = "Stripper02Cutscene",
            ["csb_tonya"] = "TonyaCutscene",
            ["csb_trafficwarden"] = "TrafficWardenCutscene",
            ["g_f_y_ballas_01"] = "Ballas01GFY",
            ["g_f_y_families_01"] = "Families01GFY",
            ["g_f_y_lost_01"] = "Lost01GFY",
            ["g_f_y_vagos_01"] = "Vagos01GFY",
            ["g_m_m_armboss_01"] = "ArmBoss01GMM",
            ["g_m_m_armgoon_01"] = "ArmGoon01GMM",
            ["g_m_m_armlieut_01"] = "ArmLieut01GMM",
            ["g_m_m_chemwork_01"] = "ChemWork01GMM",
            ["g_m_m_chiboss_01"] = "ChiBoss01GMM",
            ["g_m_m_chicold_01"] = "ChiCold01GMM",
            ["g_m_m_chigoon_01"] = "ChiGoon01GMM",
            ["g_m_m_chigoon_02"] = "ChiGoon02GMM",
            ["g_m_m_korboss_01"] = "KorBoss01GMM",
            ["g_m_m_mexboss_01"] = "MexBoss01GMM",
            ["g_m_m_mexboss_02"] = "MexBoss02GMM",
            ["g_m_y_armgoon_02"] = "ArmGoon02GMY",
            ["g_m_y_azteca_01"] = "Azteca01GMY",
            ["g_m_y_ballaeast_01"] = "BallaEast01GMY",
            ["g_m_y_ballaorig_01"] = "BallaOrig01GMY",
            ["g_m_y_ballasout_01"] = "BallaSout01GMY",
            ["g_m_y_famca_01"] = "Famca01GMY",
            ["g_m_y_famdnf_01"] = "Famdnf01GMY",
            ["g_m_y_famfor_01"] = "Famfor01GMY",
            ["g_m_y_korean_01"] = "Korean01GMY",
            ["g_m_y_korean_02"] = "Korean02GMY",
            ["g_m_y_korlieut_01"] = "KorLieut01GMY",
            ["g_m_y_lost_01"] = "Lost01GMY",
            ["g_m_y_lost_02"] = "Lost02GMY",
            ["g_m_y_lost_03"] = "Lost03GMY",
            ["g_m_y_mexgang_01"] = "MexGang01GMY",
            ["g_m_y_mexgoon_01"] = "MexGoon01GMY",
            ["g_m_y_mexgoon_02"] = "MexGoon02GMY",
            ["g_m_y_mexgoon_03"] = "MexGoon03GMY",
            ["g_m_y_pologoon_01"] = "PoloGoon01GMY",
            ["g_m_y_pologoon_02"] = "PoloGoon02GMY",
            ["g_m_y_salvaboss_01"] = "SalvaBoss01GMY",
            ["g_m_y_salvagoon_01"] = "SalvaGoon01GMY",
            ["g_m_y_salvagoon_02"] = "SalvaGoon02GMY",
            ["g_m_y_salvagoon_03"] = "SalvaGoon03GMY",
            ["g_m_y_strpunk_01"] = "StrPunk01GMY",
            ["g_m_y_strpunk_02"] = "StrPunk02GMY", 
            ["mp_g_m_pros_01"] = "MPros01",
            ["mp_m_exarmy_01"] = "ExArmy01",
            ["s_f_m_fembarber"] = "FemBarberSFM",
            ["s_f_m_maid_01"] = "Maid01SFM",
            ["s_f_m_shop_high"] = "ShopHighSFM",
            ["s_f_m_sweatshop_01"] = "Sweatshop01SFM",
            ["s_f_y_airhostess_01"] = "Airhostess01SFY",
            ["s_f_y_bartender_01"] = "Bartender01SFY",
            ["s_f_y_baywatch_01"] = "Baywatch01SFY",
            ["s_f_y_cop_01"] = "Cop01SFY",
            ["s_f_y_factory_01"] = "Factory01SFY",
            ["s_f_y_migrant_01"] = "Migrant01SFY",
            ["s_f_y_movprem_01"] = "MovPrem01SFY",
            ["s_f_y_ranger_01"] = "Ranger01SFY",
            ["s_f_y_scrubs_01"] = "Scrubs01SFY",
            ["s_f_y_sheriff_01"] = "Sheriff01SFY",
            ["s_f_y_shop_low"] = "ShopLowSFY",
            ["s_f_y_shop_mid"] = "ShopMidSFY",
            ["s_f_y_stripperlite"] = "StripperLiteSFY",
            ["s_f_y_stripper_01"] = "Stripper01SFY",
            ["s_f_y_stripper_02"] = "Stripper02SFY",
            ["s_f_y_sweatshop_01"] = "Sweatshop01SFY",
            ["s_m_m_ammucountry"] = "AmmuCountrySMM",
            ["s_m_m_armoured_01"] = "Armoured01SMM",
            ["s_m_m_armoured_02"] = "Armoured02SMM",
            ["s_m_m_autoshop_01"] = "Autoshop01SMM",
            ["s_m_m_autoshop_02"] = "Autoshop02SMM",
            ["s_m_m_bouncer_01"] = "Bouncer01SMM",
            ["s_m_m_chemsec_01"] = "ChemSec01SMM",
            ["s_m_m_ciasec_01"] = "CiaSec01SMM",
            ["s_m_m_cntrybar_01"] = "Cntrybar01SMM",
            ["s_m_m_dockwork_01"] = "Dockwork01SMM",
            ["s_m_m_doctor_01"] = "Doctor01SMM",
            ["s_m_m_fiboffice_01"] = "FibOffice01SMM",
            ["s_m_m_fiboffice_02"] = "FibOffice02SMM",
            ["s_m_m_gaffer_01"] = "Gaffer01SMM",
            ["s_m_m_gardener_01"] = "Gardener01SMM",
            ["s_m_m_gentransport"] = "GentransportSMM",
            ["s_m_m_hairdress_01"] = "Hairdress01SMM",
            ["s_m_m_highsec_01"] = "Highsec01SMM",
            ["s_m_m_highsec_02"] = "Highsec02SMM",
            ["s_m_m_janitor"] = "JanitorSMM",
            ["s_m_m_lathandy_01"] = "Lathandy01SMM",
            ["s_m_m_lifeinvad_01"] = "Lifeinvad01SMM",
            ["s_m_m_linecook"] = "LinecookSMM",
            ["s_m_m_lsmetro_01"] = "Lsmetro01SMM",
            ["s_m_m_mariachi_01"] = "Mariachi01SMM",
            ["s_m_m_marine_01"] = "Marine01SMM",
            ["s_m_m_marine_02"] = "Marine02SMM",
            ["s_m_m_migrant_01"] = "Migrant01SMM",
            ["s_m_m_movprem_01"] = "Movprem01SMM",
            ["s_m_m_movspace_01"] = "Movspace01SMM",
            ["s_m_m_paramedic_01"] = "Paramedic01SMM",
            ["s_m_m_pilot_01"] = "Pilot01SMM",
            ["s_m_m_pilot_02"] = "Pilot02SMM",
            ["s_m_m_postal_01"] = "Postal01SMM",
            ["s_m_m_postal_02"] = "Postal02SMM",
            ["s_m_m_prisguard_01"] = "Prisguard01SMM",
            ["s_m_m_scientist_01"] = "Scientist01SMM",
            ["s_m_m_security_01"] = "Security01SMM",
            ["s_m_m_snowcop_01"] = "Snowcop01SMM",
            ["s_m_m_strperf_01"] = "Strperf01SMM",
            ["s_m_m_strpreach_01"] = "Strpreach01SMM",
            ["s_m_m_strvend_01"] = "Strvend01SMM",
            ["s_m_m_trucker_01"] = "Trucker01SMM",
            ["s_m_m_ups_01"] = "Ups01SMM",
            ["s_m_m_ups_02"] = "Ups02SMM",
            ["s_m_o_busker_01"] = "Busker01SMO",
            ["s_m_y_airworker"] = "AirworkerSMY",
            ["s_m_y_ammucity_01"] = "Ammucity01SMY",
            ["s_m_y_armymech_01"] = "Armymech01SMY",
            ["s_m_y_autopsy_01"] = "Autopsy01SMY",
            ["s_m_y_barman_01"] = "Barman01SMY",
            ["s_m_y_baywatch_01"] = "Baywatch01SMY",
            ["s_m_y_blackops_01"] = "Blackops01SMY",
            ["s_m_y_blackops_02"] = "Blackops02SMY",
            ["s_m_y_busboy_01"] = "Busboy01SMY",
            ["s_m_y_chef_01"] = "Chef01SMY",
            ["s_m_y_clown_01"] = "Clown01SMY",
            ["s_m_y_construct_01"] = "Construct01SMY",
            ["s_m_y_construct_02"] = "Construct02SMY",
            ["s_m_y_cop_01"] = "Cop01SMY",
            ["s_m_y_dealer_01"] = "Dealer01SMY",
            ["s_m_y_devinsec_01"] = "Devinsec01SMY",
            ["s_m_y_dockwork_01"] = "Dockwork01SMY",
            ["s_m_y_doorman_01"] = "Doorman01SMY",
            ["s_m_y_dwservice_01"] = "DwService01SMY",
            ["s_m_y_dwservice_02"] = "DwService02SMY",
            ["s_m_y_factory_01"] = "Factory01SMY",
            ["s_m_y_fireman_01"] = "Fireman01SMY",
            ["s_m_y_garbage"] = "GarbageSMY",
            ["s_m_y_grip_01"] = "Grip01SMY",
            ["s_m_y_hwaycop_01"] = "Hwaycop01SMY",
            ["s_m_y_marine_01"] = "Marine01SMY",
            ["s_m_y_marine_02"] = "Marine02SMY",
            ["s_m_y_marine_03"] = "Marine03SMY",
            ["s_m_y_mime"] = "MimeSMY",
            ["s_m_y_pestcont_01"] = "PestCont01SMY",
            ["s_m_y_pilot_01"] = "Pilot01SMY",
            ["s_m_y_prismuscl_01"] = "PrisMuscl01SMY",
            ["s_m_y_prisoner_01"] = "Prisoner01SMY",
            ["s_m_y_ranger_01"] = "Ranger01SMY",
            ["s_m_y_robber_01"] = "Robber01SMY",
            ["s_m_y_sheriff_01"] = "Sheriff01SMY",
            ["s_m_y_shop_mask"] = "ShopMaskSMY",
            ["s_m_y_strvend_01"] = "Strvend01SMY",
            ["s_m_y_swat_01"] = "Swat01SMY",
            ["s_m_y_uscg_01"] = "Uscg01SMY",
            ["s_m_y_valet_01"] = "Valet01SMY",
            ["s_m_y_waiter_01"] = "Waiter01SMY",
            ["s_m_y_winclean_01"] = "WinClean01SMY",
            ["s_m_y_xmech_01"] = "Xmech01SMY",
            ["s_m_y_xmech_02"] = "Xmech02SMY",
            ["u_f_m_corpse_01"] = "Corpse01",
            ["u_f_m_miranda"] = "Miranda",
            ["u_f_m_promourn_01"] = "PrologueMournFemale01",
            ["u_f_o_moviestar"] = "MovieStar",
            ["u_f_o_prolhost_01"] = "PrologueHostage01",
            ["u_f_y_bikerchic"] = "BikerChic",
            ["u_f_y_comjane"] = "ComJane",
            ["u_f_y_corpse_02"] = "Corpse02",
            ["u_f_y_hotposh_01"] = "Hotposh01",
            ["u_f_y_jewelass_01"] = "Jewelass01",
            ["u_f_y_mistress"] = "Mistress",
            ["u_f_y_poppymich"] = "Poppymich",
            ["u_f_y_princess"] = "Princess",
            ["u_f_y_spyactress"] = "SpyActress",
            ["u_m_m_aldinapoli"] = "AlDiNapoli",
            ["u_m_m_bankman"] = "Bankman01",
            ["u_m_m_bikehire_01"] = "BikeHire01",
            ["u_m_m_fibarchitect"] = "FibArchitect",
            ["u_m_m_filmdirector"] = "FilmDirector",
            ["u_m_m_glenstank_01"] = "Glenstank01",
            ["u_m_m_griff_01"] = "Griff01",
            ["u_m_m_jesus_01"] = "Jesus01",
            ["u_m_m_jewelsec_01"] = "JewelSec01",
            ["u_m_m_jewelthief"] = "JewelThief",
            ["u_m_m_markfost"] = "Markfost",
            ["u_m_m_partytarget"] = "PartyTarget",
            ["u_m_m_prolsec_01"] = "PrologueSec01",
            ["u_m_m_promourn_01"] = "PrologueMournMale01",
            ["u_m_m_rivalpap"] = "RivalPaparazzi",
            ["u_m_m_spyactor"] = "SpyActor",
            ["u_m_m_willyfist"] = "WillyFist",
            ["u_m_o_finguru_01"] = "Finguru01",
            ["u_m_o_taphillbilly"] = "Taphillbilly",
            ["u_m_o_tramp_01"] = "Tramp01",
            ["u_m_y_abner"] = "Abner",
            ["u_m_y_antonb"] = "Antonb",
            ["u_m_y_babyd"] = "Babyd",
            ["u_m_y_baygor"] = "Baygor",
            ["u_m_y_burgerdrug_01"] = "BurgerDrug",
            ["u_m_y_chip"] = "Chip",
            ["u_m_y_cyclist_01"] = "Cyclist01",
            ["u_m_y_fibmugger_01"] = "FibMugger01",
            ["u_m_y_guido_01"] = "Guido01",
            ["u_m_y_gunvend_01"] = "GunVend01",
            ["u_m_y_hippie_01"] = "Hippie01",
            ["u_m_y_imporage"] = "Imporage",
            ["u_m_y_mani"] = "Mani",
            ["u_m_y_militarybum"] = "MilitaryBum",
            ["u_m_y_paparazzi"] = "Paparazzi",
            ["u_m_y_party_01"] = "Party01",
            ["u_m_y_prisoner_01"] = "Prisoner01",
            ["u_m_y_proldriver_01"] = "PrologueDriver",
            ["u_m_y_rsranger_01"] = "RsRanger01AMO",
            ["u_m_y_sbike"] = "SbikeAMO",
            ["u_m_y_staggrm_01"] = "Staggrm01AMO",
            ["u_m_y_tattoo_01"] = "Tattoo01AMO",
            ["u_m_y_zombie_01"] = "Zombie01"
        };
        Menu menu;
        
        public PedMenu()
        {
            EventHandlers["srdm:loadPed"] += new Action<string>(async pedModel =>
            {
                if(pedModel != null)
                    await setPedModel(pedModel);
            });


            menu = new Menu(Game.Player.Name, "Pick your ped");

            foreach(KeyValuePair<string, string> ped in models) 
            {
                MenuItem button = new MenuItem($"{ped.Key} ({ped.Value})", $"Pick {ped.Key} as your ped");
                menu.AddMenuItem(button);
            }

            menu.OnItemSelect += async (_menu, item, _index) =>
            {
                string[] strs = item.Text.Split(' ');
                string pedModel = strs[0];

                bool success = await setPedModel(pedModel);

                if(success)
                {
                    TriggerServerEvent("srdm:savePed", pedModel);
                }
            };

            MenuController.AddMenu(menu);
            MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Right;
            RegisterCommand("changePed", new Action(() => { menu.Visible = true; }), false);

        }

        async Task<bool> setPedModel(string pedModel)
        {
            uint pedHash = (uint)GetHashKey(pedModel);

            if (IsModelValid(pedHash) && GetEntityModel(GetPlayerPed(-1)) != pedHash)
            {
                List<WeaponHash> wpns = new List<WeaponHash>();

                foreach (WeaponHash weapon in Enum.GetValues(typeof(WeaponHash)))
                {
                    if (Game.PlayerPed.Weapons.HasWeapon(weapon))
                    {
                        wpns.Add(weapon);
                    }
                }

                RemoveAllPedWeapons(Game.PlayerPed.Handle, true);
                RequestModel(pedHash);

                while (!HasModelLoaded(pedHash))
                {
                    await Delay(10);
                }
                int health = GetEntityHealth(GetPlayerPed(-1));
                SetPlayerModel(PlayerId(), pedHash);
                SetEntityHealth(GetPlayerPed(-1), health);
                foreach (WeaponHash hash in wpns)
                {
                    Game.PlayerPed.Weapons.Give(hash, 1000, false, true);
                    Game.PlayerPed.Weapons[hash].InfiniteAmmo = true;
                }
                return true;
            }

            return false;
        }
    }
}
