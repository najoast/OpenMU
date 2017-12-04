﻿// <copyright file="00000000000000_Initial.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.EntityFramework.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// The initial migration which creates all tables etc.
    /// </summary>
    public partial class Initial : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.EnsureSchema(
                name: "config");

            migrationBuilder.CreateTable(
                name: "FriendViewItem",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Accepted = table.Column<bool>(),
                    CharacterId = table.Column<Guid>(),
                    FriendId = table.Column<Guid>(),
                    RequestOpen = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendViewItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameConfiguration",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AreaSkillHitsPlayer = table.Column<bool>(),
                    CharacterNameRegex = table.Column<string>(nullable: true),
                    InfoRange = table.Column<byte>(),
                    MaximumCharactersPerAccount = table.Column<byte>(),
                    MaximumInventoryMoney = table.Column<int>(),
                    MaximumLetters = table.Column<int>(),
                    MaximumLevel = table.Column<short>(),
                    MaximumPartySize = table.Column<byte>(),
                    MaximumPasswordLength = table.Column<int>(),
                    RecoveryInterval = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameServerConfiguration",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    MaximumNPCs = table.Column<short>(),
                    MaximumPlayers = table.Column<short>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameServerConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guild",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AllianceGuildId = table.Column<Guid>(nullable: true),
                    HostilityId = table.Column<Guid>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true),
                    Master = table.Column<string>(nullable: true),
                    MasterId = table.Column<Guid>(),
                    Name = table.Column<string>(maxLength: 8),
                    Notice = table.Column<string>(nullable: true),
                    Score = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guild_Guild_AllianceGuildId",
                        column: x => x.AllianceGuildId,
                        principalSchema: "data",
                        principalTable: "Guild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guild_Guild_HostilityId",
                        column: x => x.HostilityId,
                        principalSchema: "data",
                        principalTable: "Guild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemStorage",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Money = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStorage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerUpDefinitionValue",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AggregateType = table.Column<int>(),
                    ParentAsBoostId = table.Column<Guid>(nullable: true),
                    ParentAsDurationId = table.Column<Guid>(nullable: true),
                    Value = table.Column<float>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerUpDefinitionValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimpleCraftingSettings",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    ExcOptionChance = table.Column<byte>(),
                    LuckOptionChance = table.Column<byte>(),
                    MaxExcOptions = table.Column<byte>(),
                    Money = table.Column<int>(),
                    MultipleAllowed = table.Column<bool>(),
                    ResultItemSelect = table.Column<int>(),
                    SkillOptionChance = table.Column<byte>(),
                    SuccessPercent = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleCraftingSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Description = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    GameConfigurationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeDefinition_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DropItemGroup",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Chance = table.Column<double>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    ItemType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropItemGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropItemGroup_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemOptionType",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Description = table.Column<string>(nullable: true),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOptionType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOptionType_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSetGroup",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AlwaysApplies = table.Column<bool>(),
                    CountDistinct = table.Column<bool>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    MinimumItemCount = table.Column<int>(),
                    MinimumSetLevel = table.Column<int>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSetGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSetGroup_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSlotType",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Description = table.Column<string>(nullable: true),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    ItemSlots = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSlotType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSlotType_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterSkillRoot",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSkillRoot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterSkillRoot_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameServerDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Description = table.Column<string>(nullable: true),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    NetworkPort = table.Column<int>(),
                    ServerConfigurationId = table.Column<Guid>(nullable: true),
                    ServerID = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameServerDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameServerDefinition_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameServerDefinition_GameServerConfiguration_ServerConfigurationId",
                        column: x => x.ServerConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameServerConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MainPacketHandlerConfiguration",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AppearanceSerializerClassName = table.Column<string>(nullable: true),
                    ClientSerial = table.Column<byte[]>(nullable: true),
                    ClientVersion = table.Column<byte[]>(nullable: true),
                    GameServerConfigurationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainPacketHandlerConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainPacketHandlerConfiguration_GameServerConfiguration_GameServerConfigurationId",
                        column: x => x.GameServerConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameServerConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuildMemberInfo",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CharacterId = table.Column<Guid>(),
                    GuildId = table.Column<Guid>(),
                    ServerId = table.Column<byte>(),
                    Status = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildMemberInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildMemberInfo_Guild_GuildId",
                        column: x => x.GuildId,
                        principalSchema: "data",
                        principalTable: "Guild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    EMail = table.Column<string>(nullable: true),
                    IsVaultExtended = table.Column<bool>(),
                    LoginName = table.Column<string>(maxLength: 10),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    SecurityCode = table.Column<string>(nullable: true),
                    State = table.Column<int>(),
                    TimeZone = table.Column<short>(),
                    VaultId = table.Column<Guid>(nullable: true),
                    VaultPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_ItemStorage_VaultId",
                        column: x => x.VaultId,
                        principalSchema: "data",
                        principalTable: "ItemStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerUpDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    BoostId = table.Column<Guid>(nullable: true),
                    TargetAttributeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerUpDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerUpDefinition_PowerUpDefinitionValue_BoostId",
                        column: x => x.BoostId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinitionValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PowerUpDefinition_AttributeDefinition_TargetAttributeId",
                        column: x => x.TargetAttributeId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerUpDefinitionWithDuration",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    BoostId = table.Column<Guid>(nullable: true),
                    DurationId = table.Column<Guid>(nullable: true),
                    TargetAttributeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerUpDefinitionWithDuration", x => x.Id);
                    table.ForeignKey(
                        name: "PowerUpDefinitionWithDuration_Boost",
                        column: x => x.BoostId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinitionValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PowerUpDefinitionWithDuration_Duration",
                        column: x => x.DurationId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinitionValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PowerUpDefinitionWithDuration_AttributeDefinition_TargetAttributeId",
                        column: x => x.TargetAttributeId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PacketHandlerConfiguration",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    MainPacketHandlerConfigurationId = table.Column<Guid>(nullable: true),
                    NeedsToBeEncrypted = table.Column<bool>(),
                    PacketHandlerClassName = table.Column<string>(nullable: true),
                    PacketHandlerConfigurationId = table.Column<Guid>(nullable: true),
                    PacketIdentifier = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacketHandlerConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacketHandlerConfiguration_MainPacketHandlerConfiguration_MainPacketHandlerConfigurationId",
                        column: x => x.MainPacketHandlerConfigurationId,
                        principalSchema: "config",
                        principalTable: "MainPacketHandlerConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacketHandlerConfiguration_PacketHandlerConfiguration_PacketHandlerConfigurationId",
                        column: x => x.PacketHandlerConfigurationId,
                        principalSchema: "config",
                        principalTable: "PacketHandlerConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemOption",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Number = table.Column<int>(),
                    OptionTypeId = table.Column<Guid>(nullable: true),
                    PowerUpDefinitionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOption_ItemOptionType_OptionTypeId",
                        column: x => x.OptionTypeId,
                        principalSchema: "config",
                        principalTable: "ItemOptionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemOption_PowerUpDefinition_PowerUpDefinitionId",
                        column: x => x.PowerUpDefinitionId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MagicEffectDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    InformObservers = table.Column<bool>(),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<byte>(),
                    PowerUpDefinitionId = table.Column<Guid>(nullable: true),
                    SendDuration = table.Column<bool>(),
                    StopByDeath = table.Column<bool>(),
                    SubType = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicEffectDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicEffectDefinition_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MagicEffectDefinition_PowerUpDefinitionWithDuration_PowerUpDefinitionId",
                        column: x => x.PowerUpDefinitionId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinitionWithDuration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSetGroupItemOption",
                schema: "config",
                columns: table => new
                {
                    ItemSetGroupId = table.Column<Guid>(),
                    ItemOptionId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSetGroupItemOption", x => new { x.ItemSetGroupId, x.ItemOptionId });
                    table.ForeignKey(
                        name: "FK_ItemSetGroupItemOption_ItemOption_ItemOptionId",
                        column: x => x.ItemOptionId,
                        principalSchema: "config",
                        principalTable: "ItemOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSetGroupItemOption_ItemSetGroup_ItemSetGroupId",
                        column: x => x.ItemSetGroupId,
                        principalSchema: "config",
                        principalTable: "ItemSetGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    DamageType = table.Column<int>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    MagicEffectDefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Range = table.Column<short>(),
                    SkillID = table.Column<short>(),
                    SkillType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skill_MagicEffectDefinition_MagicEffectDefId",
                        column: x => x.MagicEffectDefId,
                        principalSchema: "config",
                        principalTable: "MagicEffectDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    ConsumeHandlerClass = table.Column<string>(nullable: true),
                    DropLevel = table.Column<byte>(),
                    DropsFromMonsters = table.Column<bool>(),
                    Durability = table.Column<byte>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    Group = table.Column<byte>(),
                    Height = table.Column<byte>(),
                    ItemSlotId = table.Column<Guid>(nullable: true),
                    MaximumSockets = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<byte>(),
                    SkillId = table.Column<Guid>(nullable: true),
                    Value = table.Column<int>(),
                    Width = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDefinition_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDefinition_ItemSlotType_ItemSlotId",
                        column: x => x.ItemSlotId,
                        principalSchema: "config",
                        principalTable: "ItemSlotType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDefinition_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelDependentDamage",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Damage = table.Column<int>(),
                    Level = table.Column<int>(),
                    SkillId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelDependentDamage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelDependentDamage_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AttackDelay = table.Column<TimeSpan>(),
                    AttackRange = table.Column<byte>(),
                    AttackSkillId = table.Column<Guid>(nullable: true),
                    Attribute = table.Column<byte>(),
                    Designation = table.Column<string>(nullable: true),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    MerchantStoreId = table.Column<Guid>(nullable: true),
                    MoveDelay = table.Column<TimeSpan>(),
                    MoveRange = table.Column<byte>(),
                    NpcWindow = table.Column<int>(),
                    Number = table.Column<short>(),
                    NumberOfMaximumItemDrops = table.Column<int>(),
                    RespawnDelay = table.Column<TimeSpan>(),
                    Skill = table.Column<short>(),
                    ViewRange = table.Column<short>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterDefinition_Skill_AttackSkillId",
                        column: x => x.AttackSkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonsterDefinition_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonsterDefinition_ItemStorage_MerchantStoreId",
                        column: x => x.MerchantStoreId,
                        principalSchema: "data",
                        principalTable: "ItemStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillPowerUpDefinition",
                schema: "config",
                columns: table => new
                {
                    Key = table.Column<int>(),
                    ValueId = table.Column<Guid>(),
                    SkillId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillPowerUpDefinition", x => new { x.Key, x.ValueId });
                    table.ForeignKey(
                        name: "FK_SkillPowerUpDefinition_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillPowerUpDefinition_PowerUpDefinition_ValueId",
                        column: x => x.ValueId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeRequirement",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AttributeId = table.Column<Guid>(nullable: true),
                    ItemDefinitionId = table.Column<Guid>(nullable: true),
                    MinimumValue = table.Column<int>(),
                    SkillId = table.Column<Guid>(nullable: true),
                    SkillId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeRequirement_AttributeDefinition_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeRequirement_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeRequirement_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeRequirement_Skill_SkillId1",
                        column: x => x.SkillId1,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DropItemGroupItemDefinition",
                schema: "config",
                columns: table => new
                {
                    DropItemGroupId = table.Column<Guid>(),
                    ItemDefinitionId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropItemGroupItemDefinition", x => new { x.DropItemGroupId, x.ItemDefinitionId });
                    table.ForeignKey(
                        name: "FK_DropItemGroupItemDefinition_DropItemGroup_DropItemGroupId",
                        column: x => x.DropItemGroupId,
                        principalSchema: "config",
                        principalTable: "DropItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DropItemGroupItemDefinition_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    DefinitionId = table.Column<Guid>(nullable: true),
                    Durability = table.Column<byte>(),
                    HasSkill = table.Column<bool>(),
                    ItemSlot = table.Column<byte>(),
                    Level = table.Column<byte>(),
                    SocketCount = table.Column<int>(),
                    StorageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_ItemDefinition_DefinitionId",
                        column: x => x.DefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ItemStorage_StorageId",
                        column: x => x.StorageId,
                        principalSchema: "data",
                        principalTable: "ItemStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemBasePowerUpDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    BaseValue = table.Column<float>(),
                    ItemDefinitionId = table.Column<Guid>(nullable: true),
                    TargetAttributeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBasePowerUpDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBasePowerUpDefinition_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemBasePowerUpDefinition_AttributeDefinition_TargetAttributeId",
                        column: x => x.TargetAttributeId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCraftingRequiredItem",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AddPercentage = table.Column<byte>(),
                    FailResult = table.Column<int>(),
                    ItemDefinitionId = table.Column<Guid>(nullable: true),
                    MinAmount = table.Column<byte>(),
                    MinLvl = table.Column<byte>(),
                    NPCPriceDiv = table.Column<int>(),
                    RefID = table.Column<byte>(),
                    SimpleCraftingSettingsId = table.Column<Guid>(nullable: true),
                    SuccessResult = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCraftingRequiredItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCraftingRequiredItem_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCraftingRequiredItem_SimpleCraftingSettings_SimpleCraftingSettingsId",
                        column: x => x.SimpleCraftingSettingsId,
                        principalSchema: "config",
                        principalTable: "SimpleCraftingSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCraftingResultItem",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AddLevel = table.Column<byte>(),
                    ItemDefinitionId = table.Column<Guid>(nullable: true),
                    RandLvlMax = table.Column<byte>(),
                    RandLvlMin = table.Column<byte>(),
                    RefID = table.Column<byte>(),
                    SimpleCraftingSettingsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCraftingResultItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCraftingResultItem_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCraftingResultItem_SimpleCraftingSettings_SimpleCraftingSettingsId",
                        column: x => x.SimpleCraftingSettingsId,
                        principalSchema: "config",
                        principalTable: "SimpleCraftingSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDefinitionItemSetGroup",
                schema: "config",
                columns: table => new
                {
                    ItemDefinitionId = table.Column<Guid>(),
                    ItemSetGroupId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDefinitionItemSetGroup", x => new { x.ItemDefinitionId, x.ItemSetGroupId });
                    table.ForeignKey(
                        name: "FK_ItemDefinitionItemSetGroup_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDefinitionItemSetGroup_ItemSetGroup_ItemSetGroupId",
                        column: x => x.ItemSetGroupId,
                        principalSchema: "config",
                        principalTable: "ItemSetGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOptionDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AddChance = table.Column<float>(),
                    AddsRandomly = table.Column<bool>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    ItemDefinitionId = table.Column<Guid>(nullable: true),
                    MaximumOptionsPerItem = table.Column<int>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOptionDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOptionDefinition_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemOptionDefinition_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JewelMix",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    MixedJewelId = table.Column<Guid>(nullable: true),
                    Number = table.Column<byte>(),
                    SingleJewelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelMix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JewelMix_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelMix_ItemDefinition_MixedJewelId",
                        column: x => x.MixedJewelId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JewelMix_ItemDefinition_SingleJewelId",
                        column: x => x.SingleJewelId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCrafting",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    ItemCraftingHandlerClassName = table.Column<string>(nullable: true),
                    MonsterDefinitionId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<byte>(),
                    SimpleCraftingSettingsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCrafting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCrafting_MonsterDefinition_MonsterDefinitionId",
                        column: x => x.MonsterDefinitionId,
                        principalSchema: "config",
                        principalTable: "MonsterDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCrafting_SimpleCraftingSettings_SimpleCraftingSettingsId",
                        column: x => x.SimpleCraftingSettingsId,
                        principalSchema: "config",
                        principalTable: "SimpleCraftingSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterAttribute",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AttributeDefinitionId = table.Column<Guid>(nullable: true),
                    MonsterDefinitionId = table.Column<Guid>(nullable: true),
                    Value = table.Column<float>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterAttribute_AttributeDefinition_AttributeDefinitionId",
                        column: x => x.AttributeDefinitionId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonsterAttribute_MonsterDefinition_MonsterDefinitionId",
                        column: x => x.MonsterDefinitionId,
                        principalSchema: "config",
                        principalTable: "MonsterDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterDefinitionDropItemGroup",
                schema: "config",
                columns: table => new
                {
                    MonsterDefinitionId = table.Column<Guid>(),
                    DropItemGroupId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterDefinitionDropItemGroup", x => new { x.MonsterDefinitionId, x.DropItemGroupId });
                    table.ForeignKey(
                        name: "FK_MonsterDefinitionDropItemGroup_DropItemGroup_DropItemGroupId",
                        column: x => x.DropItemGroupId,
                        principalSchema: "config",
                        principalTable: "DropItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterDefinitionDropItemGroup_MonsterDefinition_MonsterDefinitionId",
                        column: x => x.MonsterDefinitionId,
                        principalSchema: "config",
                        principalTable: "MonsterDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemItemSetGroup",
                schema: "data",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(),
                    ItemSetGroupId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemItemSetGroup", x => new { x.ItemId, x.ItemSetGroupId });
                    table.ForeignKey(
                        name: "FK_ItemItemSetGroup_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "data",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemItemSetGroup_ItemSetGroup_ItemSetGroupId",
                        column: x => x.ItemSetGroupId,
                        principalSchema: "config",
                        principalTable: "ItemSetGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOptionLink",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    ItemId = table.Column<Guid>(nullable: true),
                    ItemOptionId = table.Column<Guid>(nullable: true),
                    Level = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOptionLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOptionLink_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "data",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemOptionLink_ItemOption_ItemOptionId",
                        column: x => x.ItemOptionId,
                        principalSchema: "config",
                        principalTable: "ItemOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelBonus",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AdditionalValue = table.Column<float>(),
                    ItemBasePowerUpDefinitionId = table.Column<Guid>(nullable: true),
                    Level = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelBonus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelBonus_ItemBasePowerUpDefinition_ItemBasePowerUpDefinitionId",
                        column: x => x.ItemBasePowerUpDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemBasePowerUpDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCraftingRequiredItemItemOptionType",
                schema: "config",
                columns: table => new
                {
                    ItemCraftingRequiredItemId = table.Column<Guid>(),
                    ItemOptionTypeId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCraftingRequiredItemItemOptionType", x => new { x.ItemCraftingRequiredItemId, x.ItemOptionTypeId });
                    table.ForeignKey(
                        name: "FK_ItemCraftingRequiredItemItemOptionType_ItemCraftingRequiredItem_ItemCraftingRequiredItemId",
                        column: x => x.ItemCraftingRequiredItemId,
                        principalSchema: "config",
                        principalTable: "ItemCraftingRequiredItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCraftingRequiredItemItemOptionType_ItemOptionType_ItemOptionTypeId",
                        column: x => x.ItemOptionTypeId,
                        principalSchema: "config",
                        principalTable: "ItemOptionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncreasableItemOption",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    ItemOptionDefinitionId = table.Column<Guid>(nullable: true),
                    Number = table.Column<int>(),
                    OptionTypeId = table.Column<Guid>(nullable: true),
                    PowerUpDefinitionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncreasableItemOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncreasableItemOption_ItemOptionDefinition_ItemOptionDefinitionId",
                        column: x => x.ItemOptionDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemOptionDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncreasableItemOption_ItemOptionType_OptionTypeId",
                        column: x => x.OptionTypeId,
                        principalSchema: "config",
                        principalTable: "ItemOptionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncreasableItemOption_PowerUpDefinition_PowerUpDefinitionId",
                        column: x => x.PowerUpDefinitionId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemOfItemSet",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    BonusOptionId = table.Column<Guid>(nullable: true),
                    ItemDefinitionId = table.Column<Guid>(nullable: true),
                    ItemSetGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfItemSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOfItemSet_IncreasableItemOption_BonusOptionId",
                        column: x => x.BonusOptionId,
                        principalSchema: "config",
                        principalTable: "IncreasableItemOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemOfItemSet_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemOfItemSet_ItemSetGroup_ItemSetGroupId",
                        column: x => x.ItemSetGroupId,
                        principalSchema: "config",
                        principalTable: "ItemSetGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemOptionOfLevel",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    IncreasableItemOptionId = table.Column<Guid>(nullable: true),
                    Level = table.Column<int>(),
                    PowerUpDefinitionId = table.Column<Guid>(nullable: true),
                    RequiredItemLevel = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOptionOfLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOptionOfLevel_IncreasableItemOption_IncreasableItemOptionId",
                        column: x => x.IncreasableItemOptionId,
                        principalSchema: "config",
                        principalTable: "IncreasableItemOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemOptionOfLevel_PowerUpDefinition_PowerUpDefinitionId",
                        column: x => x.PowerUpDefinitionId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountCharacterClass",
                schema: "data",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(),
                    CharacterClassId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCharacterClass", x => new { x.AccountId, x.CharacterClassId });
                    table.ForeignKey(
                        name: "FK_AccountCharacterClass_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "data",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AccountId = table.Column<Guid>(nullable: true),
                    CharacterClassId = table.Column<Guid>(),
                    CharacterSlot = table.Column<byte>(),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CurrentMapId = table.Column<Guid>(nullable: true),
                    Experience = table.Column<long>(),
                    GuildMemberInfoId = table.Column<Guid>(nullable: true),
                    InventoryExtensions = table.Column<int>(),
                    InventoryId = table.Column<Guid>(nullable: true),
                    KeyConfiguration = table.Column<byte[]>(nullable: true),
                    LevelUpPoints = table.Column<int>(),
                    MasterExperience = table.Column<long>(),
                    MasterLevelUpPoints = table.Column<int>(),
                    Money = table.Column<int>(),
                    Name = table.Column<string>(maxLength: 10),
                    PlayerKillCount = table.Column<int>(),
                    PositionX = table.Column<byte>(),
                    PositionY = table.Column<byte>(),
                    QuestInfo = table.Column<byte[]>(nullable: true),
                    State = table.Column<int>(),
                    StateRemainingSeconds = table.Column<int>(),
                    UsedFruitPoints = table.Column<int>(),
                    UsedNegFruitPoints = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "data",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_GuildMemberInfo_GuildMemberInfoId",
                        column: x => x.GuildMemberInfoId,
                        principalSchema: "data",
                        principalTable: "GuildMemberInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_ItemStorage_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "data",
                        principalTable: "ItemStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterDropItemGroup",
                schema: "data",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(),
                    DropItemGroupId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterDropItemGroup", x => new { x.CharacterId, x.DropItemGroupId });
                    table.ForeignKey(
                        name: "FK_CharacterDropItemGroup_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "data",
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterDropItemGroup_DropItemGroup_DropItemGroupId",
                        column: x => x.DropItemGroupId,
                        principalSchema: "config",
                        principalTable: "DropItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LetterHeader",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CharacterId = table.Column<Guid>(nullable: true),
                    LetterDate = table.Column<DateTime>(),
                    ReadFlag = table.Column<bool>(),
                    Receiver = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterHeader_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "data",
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillEntry",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CharacterId = table.Column<Guid>(nullable: true),
                    Level = table.Column<int>(),
                    SkillId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillEntry_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "data",
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillEntry_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatAttribute",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CharacterId = table.Column<Guid>(nullable: true),
                    DefinitionId = table.Column<Guid>(nullable: true),
                    Value = table.Column<float>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatAttribute_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "data",
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatAttribute_AttributeDefinition_DefinitionId",
                        column: x => x.DefinitionId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributeRelationship",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CharacterClassId = table.Column<Guid>(nullable: true),
                    InputAttributeId = table.Column<Guid>(nullable: true),
                    InputOperand = table.Column<float>(),
                    InputOperator = table.Column<int>(),
                    PowerUpDefinitionValueId = table.Column<Guid>(nullable: true),
                    TargetAttributeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeRelationship_AttributeDefinition_InputAttributeId",
                        column: x => x.InputAttributeId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeRelationship_PowerUpDefinitionValue_PowerUpDefinitionValueId",
                        column: x => x.PowerUpDefinitionValueId,
                        principalSchema: "config",
                        principalTable: "PowerUpDefinitionValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeRelationship_AttributeDefinition_TargetAttributeId",
                        column: x => x.TargetAttributeId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConstValueAttribute",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CharacterClassId = table.Column<Guid>(),
                    DefinitionId = table.Column<Guid>(nullable: true),
                    Value = table.Column<float>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstValueAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstValueAttribute_AttributeDefinition_DefinitionId",
                        column: x => x.DefinitionId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatAttributeDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    AttributeId = table.Column<Guid>(nullable: true),
                    BaseValue = table.Column<float>(),
                    CharacterClassId = table.Column<Guid>(nullable: true),
                    IncreasableByPlayer = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatAttributeDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatAttributeDefinition_AttributeDefinition_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "config",
                        principalTable: "AttributeDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDefinitionCharacterClass",
                schema: "config",
                columns: table => new
                {
                    ItemDefinitionId = table.Column<Guid>(),
                    CharacterClassId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDefinitionCharacterClass", x => new { x.ItemDefinitionId, x.CharacterClassId });
                    table.ForeignKey(
                        name: "FK_ItemDefinitionCharacterClass_ItemDefinition_ItemDefinitionId",
                        column: x => x.ItemDefinitionId,
                        principalSchema: "config",
                        principalTable: "ItemDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterSkillDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CharacterClassId = table.Column<Guid>(nullable: true),
                    Rank = table.Column<byte>(),
                    RootId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSkillDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterSkillDefinition_MasterSkillRoot_RootId",
                        column: x => x.RootId,
                        principalSchema: "config",
                        principalTable: "MasterSkillRoot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterSkillDefinitionSkill",
                schema: "config",
                columns: table => new
                {
                    MasterSkillDefinitionId = table.Column<Guid>(),
                    SkillId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSkillDefinitionSkill", x => new { x.MasterSkillDefinitionId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_MasterSkillDefinitionSkill_MasterSkillDefinition_MasterSkillDefinitionId",
                        column: x => x.MasterSkillDefinitionId,
                        principalSchema: "config",
                        principalTable: "MasterSkillDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterSkillDefinitionSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillMasterSkillDefinition",
                schema: "config",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(),
                    MasterSkillDefinitionId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillMasterSkillDefinition", x => new { x.SkillId, x.MasterSkillDefinitionId });
                    table.ForeignKey(
                        name: "FK_SkillMasterSkillDefinition_MasterSkillDefinition_MasterSkillDefinitionId",
                        column: x => x.MasterSkillDefinitionId,
                        principalSchema: "config",
                        principalTable: "MasterSkillDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillMasterSkillDefinition_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillCharacterClass",
                schema: "config",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(),
                    CharacterClassId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCharacterClass", x => new { x.SkillId, x.CharacterClassId });
                    table.ForeignKey(
                        name: "FK_SkillCharacterClass_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameMapDefinitionDropItemGroup",
                schema: "config",
                columns: table => new
                {
                    GameMapDefinitionId = table.Column<Guid>(),
                    DropItemGroupId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMapDefinitionDropItemGroup", x => new { x.GameMapDefinitionId, x.DropItemGroupId });
                    table.ForeignKey(
                        name: "FK_GameMapDefinitionDropItemGroup_DropItemGroup_DropItemGroupId",
                        column: x => x.DropItemGroupId,
                        principalSchema: "config",
                        principalTable: "DropItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnterGate",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    GameMapDefinitionId = table.Column<Guid>(nullable: true),
                    LevelRequirement = table.Column<short>(),
                    Number = table.Column<short>(),
                    TargetGateId = table.Column<Guid>(nullable: true),
                    X1 = table.Column<byte>(),
                    X2 = table.Column<byte>(),
                    Y1 = table.Column<byte>(),
                    Y2 = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterGate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameMapDefinition",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    DeathSafezoneId = table.Column<Guid>(nullable: true),
                    ExpMultiplier = table.Column<double>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    GameServerConfigurationId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<short>(),
                    TerrainData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMapDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameMapDefinition_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameMapDefinition_GameServerConfiguration_GameServerConfigurationId",
                        column: x => x.GameServerConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameServerConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CanGetCreated = table.Column<bool>(),
                    CreationAllowedFlag = table.Column<byte>(),
                    GameConfigurationId = table.Column<Guid>(nullable: true),
                    HomeMapId = table.Column<Guid>(nullable: true),
                    IsMasterClass = table.Column<bool>(),
                    LevelRequirementByCreation = table.Column<short>(),
                    LevelWarpRequirementReductionPercent = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    NextGenerationClassId = table.Column<Guid>(nullable: true),
                    Number = table.Column<byte>(),
                    PointsPerLevelUp = table.Column<short>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterClass_GameConfiguration_GameConfigurationId",
                        column: x => x.GameConfigurationId,
                        principalSchema: "config",
                        principalTable: "GameConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterClass_GameMapDefinition_HomeMapId",
                        column: x => x.HomeMapId,
                        principalSchema: "config",
                        principalTable: "GameMapDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterClass_CharacterClass_NextGenerationClassId",
                        column: x => x.NextGenerationClassId,
                        principalSchema: "config",
                        principalTable: "CharacterClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExitGate",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Direction = table.Column<int>(),
                    MapId = table.Column<Guid>(nullable: true),
                    X1 = table.Column<byte>(),
                    X2 = table.Column<byte>(),
                    Y1 = table.Column<byte>(),
                    Y2 = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExitGate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExitGate_GameMapDefinition_MapId",
                        column: x => x.MapId,
                        principalSchema: "config",
                        principalTable: "GameMapDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterSpawnArea",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Direction = table.Column<int>(),
                    GameMapId = table.Column<Guid>(nullable: true),
                    MonsterDefinitionId = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<short>(),
                    SpawnTrigger = table.Column<int>(),
                    X1 = table.Column<byte>(),
                    X2 = table.Column<byte>(),
                    Y1 = table.Column<byte>(),
                    Y2 = table.Column<byte>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterSpawnArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterSpawnArea_GameMapDefinition_GameMapId",
                        column: x => x.GameMapId,
                        principalSchema: "config",
                        principalTable: "GameMapDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonsterSpawnArea_MonsterDefinition_MonsterDefinitionId",
                        column: x => x.MonsterDefinitionId,
                        principalSchema: "config",
                        principalTable: "MonsterDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_LoginName",
                schema: "data",
                table: "Account",
                column: "LoginName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_VaultId",
                schema: "data",
                table: "Account",
                column: "VaultId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCharacterClass_CharacterClassId",
                schema: "data",
                table: "AccountCharacterClass",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDefinition_GameConfigurationId",
                schema: "config",
                table: "AttributeDefinition",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRelationship_CharacterClassId",
                schema: "config",
                table: "AttributeRelationship",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRelationship_InputAttributeId",
                schema: "config",
                table: "AttributeRelationship",
                column: "InputAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRelationship_PowerUpDefinitionValueId",
                schema: "config",
                table: "AttributeRelationship",
                column: "PowerUpDefinitionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRelationship_TargetAttributeId",
                schema: "config",
                table: "AttributeRelationship",
                column: "TargetAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRequirement_AttributeId",
                schema: "config",
                table: "AttributeRequirement",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRequirement_ItemDefinitionId",
                schema: "config",
                table: "AttributeRequirement",
                column: "ItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRequirement_SkillId",
                schema: "config",
                table: "AttributeRequirement",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeRequirement_SkillId1",
                schema: "config",
                table: "AttributeRequirement",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_Character_AccountId",
                schema: "data",
                table: "Character",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterClassId",
                schema: "data",
                table: "Character",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CurrentMapId",
                schema: "data",
                table: "Character",
                column: "CurrentMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_GuildMemberInfoId",
                schema: "data",
                table: "Character",
                column: "GuildMemberInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_InventoryId",
                schema: "data",
                table: "Character",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Name",
                schema: "data",
                table: "Character",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_GameConfigurationId",
                schema: "config",
                table: "CharacterClass",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_HomeMapId",
                schema: "config",
                table: "CharacterClass",
                column: "HomeMapId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_NextGenerationClassId",
                schema: "config",
                table: "CharacterClass",
                column: "NextGenerationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterDropItemGroup_DropItemGroupId",
                schema: "data",
                table: "CharacterDropItemGroup",
                column: "DropItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstValueAttribute_CharacterClassId",
                schema: "config",
                table: "ConstValueAttribute",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstValueAttribute_DefinitionId",
                schema: "config",
                table: "ConstValueAttribute",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_DropItemGroup_GameConfigurationId",
                schema: "config",
                table: "DropItemGroup",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_DropItemGroupItemDefinition_ItemDefinitionId",
                schema: "config",
                table: "DropItemGroupItemDefinition",
                column: "ItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterGate_GameMapDefinitionId",
                schema: "config",
                table: "EnterGate",
                column: "GameMapDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterGate_TargetGateId",
                schema: "config",
                table: "EnterGate",
                column: "TargetGateId");

            migrationBuilder.CreateIndex(
                name: "IX_ExitGate_MapId",
                schema: "config",
                table: "ExitGate",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMapDefinition_DeathSafezoneId",
                schema: "config",
                table: "GameMapDefinition",
                column: "DeathSafezoneId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMapDefinition_GameConfigurationId",
                schema: "config",
                table: "GameMapDefinition",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMapDefinition_GameServerConfigurationId",
                schema: "config",
                table: "GameMapDefinition",
                column: "GameServerConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMapDefinitionDropItemGroup_DropItemGroupId",
                schema: "config",
                table: "GameMapDefinitionDropItemGroup",
                column: "DropItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GameServerDefinition_GameConfigurationId",
                schema: "config",
                table: "GameServerDefinition",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_GameServerDefinition_ServerConfigurationId",
                schema: "config",
                table: "GameServerDefinition",
                column: "ServerConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Guild_AllianceGuildId",
                schema: "data",
                table: "Guild",
                column: "AllianceGuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Guild_HostilityId",
                schema: "data",
                table: "Guild",
                column: "HostilityId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildMemberInfo_GuildId",
                schema: "data",
                table: "GuildMemberInfo",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_IncreasableItemOption_ItemOptionDefinitionId",
                schema: "config",
                table: "IncreasableItemOption",
                column: "ItemOptionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_IncreasableItemOption_OptionTypeId",
                schema: "config",
                table: "IncreasableItemOption",
                column: "OptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncreasableItemOption_PowerUpDefinitionId",
                schema: "config",
                table: "IncreasableItemOption",
                column: "PowerUpDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_DefinitionId",
                schema: "data",
                table: "Item",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_StorageId",
                schema: "data",
                table: "Item",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBasePowerUpDefinition_ItemDefinitionId",
                schema: "config",
                table: "ItemBasePowerUpDefinition",
                column: "ItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBasePowerUpDefinition_TargetAttributeId",
                schema: "config",
                table: "ItemBasePowerUpDefinition",
                column: "TargetAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCrafting_MonsterDefinitionId",
                schema: "config",
                table: "ItemCrafting",
                column: "MonsterDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCrafting_SimpleCraftingSettingsId",
                schema: "config",
                table: "ItemCrafting",
                column: "SimpleCraftingSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCraftingRequiredItem_ItemDefinitionId",
                schema: "config",
                table: "ItemCraftingRequiredItem",
                column: "ItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCraftingRequiredItem_SimpleCraftingSettingsId",
                schema: "config",
                table: "ItemCraftingRequiredItem",
                column: "SimpleCraftingSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCraftingRequiredItemItemOptionType_ItemOptionTypeId",
                schema: "config",
                table: "ItemCraftingRequiredItemItemOptionType",
                column: "ItemOptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCraftingResultItem_ItemDefinitionId",
                schema: "config",
                table: "ItemCraftingResultItem",
                column: "ItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCraftingResultItem_SimpleCraftingSettingsId",
                schema: "config",
                table: "ItemCraftingResultItem",
                column: "SimpleCraftingSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefinition_GameConfigurationId",
                schema: "config",
                table: "ItemDefinition",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefinition_ItemSlotId",
                schema: "config",
                table: "ItemDefinition",
                column: "ItemSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefinition_SkillId",
                schema: "config",
                table: "ItemDefinition",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefinitionCharacterClass_CharacterClassId",
                schema: "config",
                table: "ItemDefinitionCharacterClass",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDefinitionItemSetGroup_ItemSetGroupId",
                schema: "config",
                table: "ItemDefinitionItemSetGroup",
                column: "ItemSetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemItemSetGroup_ItemSetGroupId",
                schema: "data",
                table: "ItemItemSetGroup",
                column: "ItemSetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfItemSet_BonusOptionId",
                schema: "config",
                table: "ItemOfItemSet",
                column: "BonusOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfItemSet_ItemDefinitionId",
                schema: "config",
                table: "ItemOfItemSet",
                column: "ItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfItemSet_ItemSetGroupId",
                schema: "config",
                table: "ItemOfItemSet",
                column: "ItemSetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOption_OptionTypeId",
                schema: "config",
                table: "ItemOption",
                column: "OptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOption_PowerUpDefinitionId",
                schema: "config",
                table: "ItemOption",
                column: "PowerUpDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionDefinition_GameConfigurationId",
                schema: "config",
                table: "ItemOptionDefinition",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionDefinition_ItemDefinitionId",
                schema: "config",
                table: "ItemOptionDefinition",
                column: "ItemDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionLink_ItemId",
                schema: "data",
                table: "ItemOptionLink",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionLink_ItemOptionId",
                schema: "data",
                table: "ItemOptionLink",
                column: "ItemOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionOfLevel_IncreasableItemOptionId",
                schema: "config",
                table: "ItemOptionOfLevel",
                column: "IncreasableItemOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionOfLevel_PowerUpDefinitionId",
                schema: "config",
                table: "ItemOptionOfLevel",
                column: "PowerUpDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionType_GameConfigurationId",
                schema: "config",
                table: "ItemOptionType",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSetGroup_GameConfigurationId",
                schema: "config",
                table: "ItemSetGroup",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSetGroupItemOption_ItemOptionId",
                schema: "config",
                table: "ItemSetGroupItemOption",
                column: "ItemOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSlotType_GameConfigurationId",
                schema: "config",
                table: "ItemSlotType",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelMix_GameConfigurationId",
                schema: "config",
                table: "JewelMix",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelMix_MixedJewelId",
                schema: "config",
                table: "JewelMix",
                column: "MixedJewelId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelMix_SingleJewelId",
                schema: "config",
                table: "JewelMix",
                column: "SingleJewelId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterHeader_CharacterId",
                schema: "data",
                table: "LetterHeader",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelBonus_ItemBasePowerUpDefinitionId",
                schema: "config",
                table: "LevelBonus",
                column: "ItemBasePowerUpDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelDependentDamage_SkillId",
                schema: "config",
                table: "LevelDependentDamage",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicEffectDefinition_GameConfigurationId",
                schema: "config",
                table: "MagicEffectDefinition",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicEffectDefinition_PowerUpDefinitionId",
                schema: "config",
                table: "MagicEffectDefinition",
                column: "PowerUpDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_MainPacketHandlerConfiguration_GameServerConfigurationId",
                schema: "config",
                table: "MainPacketHandlerConfiguration",
                column: "GameServerConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSkillDefinition_CharacterClassId",
                schema: "config",
                table: "MasterSkillDefinition",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSkillDefinition_RootId",
                schema: "config",
                table: "MasterSkillDefinition",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSkillDefinitionSkill_SkillId",
                schema: "config",
                table: "MasterSkillDefinitionSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSkillRoot_GameConfigurationId",
                schema: "config",
                table: "MasterSkillRoot",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterAttribute_AttributeDefinitionId",
                schema: "config",
                table: "MonsterAttribute",
                column: "AttributeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterAttribute_MonsterDefinitionId",
                schema: "config",
                table: "MonsterAttribute",
                column: "MonsterDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterDefinition_AttackSkillId",
                schema: "config",
                table: "MonsterDefinition",
                column: "AttackSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterDefinition_GameConfigurationId",
                schema: "config",
                table: "MonsterDefinition",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterDefinition_MerchantStoreId",
                schema: "config",
                table: "MonsterDefinition",
                column: "MerchantStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterDefinitionDropItemGroup_DropItemGroupId",
                schema: "config",
                table: "MonsterDefinitionDropItemGroup",
                column: "DropItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSpawnArea_GameMapId",
                schema: "config",
                table: "MonsterSpawnArea",
                column: "GameMapId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSpawnArea_MonsterDefinitionId",
                schema: "config",
                table: "MonsterSpawnArea",
                column: "MonsterDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PacketHandlerConfiguration_MainPacketHandlerConfigurationId",
                schema: "config",
                table: "PacketHandlerConfiguration",
                column: "MainPacketHandlerConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_PacketHandlerConfiguration_PacketHandlerConfigurationId",
                schema: "config",
                table: "PacketHandlerConfiguration",
                column: "PacketHandlerConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerUpDefinition_BoostId",
                schema: "config",
                table: "PowerUpDefinition",
                column: "BoostId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerUpDefinition_TargetAttributeId",
                schema: "config",
                table: "PowerUpDefinition",
                column: "TargetAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerUpDefinitionWithDuration_BoostId",
                schema: "config",
                table: "PowerUpDefinitionWithDuration",
                column: "BoostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerUpDefinitionWithDuration_DurationId",
                schema: "config",
                table: "PowerUpDefinitionWithDuration",
                column: "DurationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerUpDefinitionWithDuration_TargetAttributeId",
                schema: "config",
                table: "PowerUpDefinitionWithDuration",
                column: "TargetAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_GameConfigurationId",
                schema: "config",
                table: "Skill",
                column: "GameConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_MagicEffectDefId",
                schema: "config",
                table: "Skill",
                column: "MagicEffectDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCharacterClass_CharacterClassId",
                schema: "config",
                table: "SkillCharacterClass",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillEntry_CharacterId",
                schema: "data",
                table: "SkillEntry",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillEntry_SkillId",
                schema: "data",
                table: "SkillEntry",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillMasterSkillDefinition_MasterSkillDefinitionId",
                schema: "config",
                table: "SkillMasterSkillDefinition",
                column: "MasterSkillDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillPowerUpDefinition_SkillId",
                schema: "config",
                table: "SkillPowerUpDefinition",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillPowerUpDefinition_ValueId",
                schema: "config",
                table: "SkillPowerUpDefinition",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_StatAttribute_CharacterId",
                schema: "data",
                table: "StatAttribute",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StatAttribute_DefinitionId",
                schema: "data",
                table: "StatAttribute",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_StatAttributeDefinition_AttributeId",
                schema: "config",
                table: "StatAttributeDefinition",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatAttributeDefinition_CharacterClassId",
                schema: "config",
                table: "StatAttributeDefinition",
                column: "CharacterClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountCharacterClass_CharacterClass_CharacterClassId",
                schema: "data",
                table: "AccountCharacterClass",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassId",
                schema: "data",
                table: "Character",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_GameMapDefinition_CurrentMapId",
                schema: "data",
                table: "Character",
                column: "CurrentMapId",
                principalSchema: "config",
                principalTable: "GameMapDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeRelationship_CharacterClass_CharacterClassId",
                schema: "config",
                table: "AttributeRelationship",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstValueAttribute_CharacterClass_CharacterClassId",
                schema: "config",
                table: "ConstValueAttribute",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatAttributeDefinition_CharacterClass_CharacterClassId",
                schema: "config",
                table: "StatAttributeDefinition",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDefinitionCharacterClass_CharacterClass_CharacterClassId",
                schema: "config",
                table: "ItemDefinitionCharacterClass",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterSkillDefinition_CharacterClass_CharacterClassId",
                schema: "config",
                table: "MasterSkillDefinition",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillCharacterClass_CharacterClass_CharacterClassId",
                schema: "config",
                table: "SkillCharacterClass",
                column: "CharacterClassId",
                principalSchema: "config",
                principalTable: "CharacterClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameMapDefinitionDropItemGroup_GameMapDefinition_GameMapDefinitionId",
                schema: "config",
                table: "GameMapDefinitionDropItemGroup",
                column: "GameMapDefinitionId",
                principalSchema: "config",
                principalTable: "GameMapDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterGate_GameMapDefinition_GameMapDefinitionId",
                schema: "config",
                table: "EnterGate",
                column: "GameMapDefinitionId",
                principalSchema: "config",
                principalTable: "GameMapDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterGate_ExitGate_TargetGateId",
                schema: "config",
                table: "EnterGate",
                column: "TargetGateId",
                principalSchema: "config",
                principalTable: "ExitGate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameMapDefinition_ExitGate_DeathSafezoneId",
                schema: "config",
                table: "GameMapDefinition",
                column: "DeathSafezoneId",
                principalSchema: "config",
                principalTable: "ExitGate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql($"DROP ROLE IF EXISTS {ConnectionConfigurator.GetRoleName(DatabaseRole.Account)}, {ConnectionConfigurator.GetRoleName(DatabaseRole.Configuration)};");

            var accountRoleName = ConnectionConfigurator.GetRoleName(DatabaseRole.Account);

            migrationBuilder.Sql($"CREATE ROLE {accountRoleName} WITH LOGIN PASSWORD '{ConnectionConfigurator.GetRolePassword(DatabaseRole.Account)}';");

            migrationBuilder.Sql($"GRANT SELECT, UPDATE, INSERT, DELETE ON ALL TABLES IN SCHEMA data TO GROUP {accountRoleName};");

            migrationBuilder.Sql($"GRANT USAGE ON SCHEMA data TO GROUP {accountRoleName};");

            var configRoleName = ConnectionConfigurator.GetRoleName(DatabaseRole.Configuration);

            migrationBuilder.Sql($"CREATE ROLE {configRoleName} WITH LOGIN PASSWORD '{ConnectionConfigurator.GetRolePassword(DatabaseRole.Configuration)}';");

            migrationBuilder.Sql($"GRANT SELECT ON ALL TABLES IN SCHEMA config TO GROUP {configRoleName};");
            migrationBuilder.Sql($"GRANT SELECT ON TABLE data.\"Item\", data.\"ItemOptionLink\", data.\"ItemItemSetGroup\", data.\"ItemStorage\" TO GROUP {configRoleName};");

            migrationBuilder.Sql($"GRANT USAGE ON SCHEMA data, config TO GROUP {configRoleName};");
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP ROLE IF EXISTS {ConnectionConfigurator.GetRoleName(DatabaseRole.Account)};");
            migrationBuilder.Sql($"DROP ROLE IF EXISTS {ConnectionConfigurator.GetRoleName(DatabaseRole.Configuration)};");

            migrationBuilder.DropForeignKey(
                name: "FK_GameMapDefinition_GameConfiguration_GameConfigurationId",
                schema: "config",
                table: "GameMapDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_ExitGate_GameMapDefinition_MapId",
                schema: "config",
                table: "ExitGate");

            migrationBuilder.DropTable(
                name: "AccountCharacterClass",
                schema: "data");

            migrationBuilder.DropTable(
                name: "AttributeRelationship",
                schema: "config");

            migrationBuilder.DropTable(
                name: "AttributeRequirement",
                schema: "config");

            migrationBuilder.DropTable(
                name: "CharacterDropItemGroup",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ConstValueAttribute",
                schema: "config");

            migrationBuilder.DropTable(
                name: "DropItemGroupItemDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "EnterGate",
                schema: "config");

            migrationBuilder.DropTable(
                name: "FriendViewItem",
                schema: "data");

            migrationBuilder.DropTable(
                name: "GameMapDefinitionDropItemGroup",
                schema: "config");

            migrationBuilder.DropTable(
                name: "GameServerDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemCrafting",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemCraftingRequiredItemItemOptionType",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemCraftingResultItem",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemDefinitionCharacterClass",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemDefinitionItemSetGroup",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemItemSetGroup",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ItemOfItemSet",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemOptionLink",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ItemOptionOfLevel",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemSetGroupItemOption",
                schema: "config");

            migrationBuilder.DropTable(
                name: "JewelMix",
                schema: "config");

            migrationBuilder.DropTable(
                name: "LetterHeader",
                schema: "data");

            migrationBuilder.DropTable(
                name: "LevelBonus",
                schema: "config");

            migrationBuilder.DropTable(
                name: "LevelDependentDamage",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MasterSkillDefinitionSkill",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MonsterAttribute",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MonsterDefinitionDropItemGroup",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MonsterSpawnArea",
                schema: "config");

            migrationBuilder.DropTable(
                name: "PacketHandlerConfiguration",
                schema: "config");

            migrationBuilder.DropTable(
                name: "SkillCharacterClass",
                schema: "config");

            migrationBuilder.DropTable(
                name: "SkillEntry",
                schema: "data");

            migrationBuilder.DropTable(
                name: "SkillMasterSkillDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "SkillPowerUpDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "StatAttribute",
                schema: "data");

            migrationBuilder.DropTable(
                name: "StatAttributeDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemCraftingRequiredItem",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "data");

            migrationBuilder.DropTable(
                name: "IncreasableItemOption",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemOption",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemSetGroup",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemBasePowerUpDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "DropItemGroup",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MonsterDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MainPacketHandlerConfiguration",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MasterSkillDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Character",
                schema: "data");

            migrationBuilder.DropTable(
                name: "SimpleCraftingSettings",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemOptionDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemOptionType",
                schema: "config");

            migrationBuilder.DropTable(
                name: "PowerUpDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MasterSkillRoot",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "data");

            migrationBuilder.DropTable(
                name: "CharacterClass",
                schema: "config");

            migrationBuilder.DropTable(
                name: "GuildMemberInfo",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ItemDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ItemStorage",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Guild",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ItemSlotType",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Skill",
                schema: "config");

            migrationBuilder.DropTable(
                name: "MagicEffectDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "PowerUpDefinitionWithDuration",
                schema: "config");

            migrationBuilder.DropTable(
                name: "PowerUpDefinitionValue",
                schema: "config");

            migrationBuilder.DropTable(
                name: "AttributeDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "GameConfiguration",
                schema: "config");

            migrationBuilder.DropTable(
                name: "GameMapDefinition",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ExitGate",
                schema: "config");

            migrationBuilder.DropTable(
                name: "GameServerConfiguration",
                schema: "config");
        }
    }
}